﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MoveState
{
	Idle,
	Walk,
	Steer
}

public enum Filter
{
	Interactable,
	Grab,
	Activate
}

public class PlayerController : MonoBehaviour {

	static public PlayerController instance;

    [Header("Components")]
	public Transform self;
	public Rigidbody body;
    public Transform holdPoint;
    public Animator anim;
    public AudioSource myAudioSource;

	[Space]
	[Header("Referencies")]
	public GameObject actionUI;
	public GameObject grabbedActionUI;
	Text actionText;
	Text grabbedActionText;
	public GameObject steerParticlesPrefab;
    public GameObject grabParticlesPrefab;
    public GameObject dropParticlesPrefab;
    public AudioClip steerClip;
    public AudioClip grabClip;
    public AudioClip dropClip;

	[Space]
	[Header("Inputs")]
	public KeyCode actionKey;
	public KeyCode grabKey;
    public float deadzone = 0.2f;

	[Space]
	[Header("Controls")]
	public MoveState moveState;
	[SerializeField] private float speed;
	[Tooltip("Minimum required speed to go to walking state")] public float minWalkSpeed = 0.1f;
	public float maxSpeed = 10;
	public float maxAcceleration = 10;
	public AnimationCurve accelerationCurve;
	[Space]
    public float movingDrag = .4f;
    public float idleDrag = .4f;
	public float steerDrag;
	[Space]
	[Range(0.01f, 1f)]
    public float turnSpeed = .25f;
	[Tooltip("Minimum required speed to go to steering state")] [Range(0.01f, 1f)] public float steerThresholdSpeed;
    public AnimationCurve walkAnimationSpeedCurve;


	[Space]
	[Header("Grab")]
	[Tooltip("Distance forward to check for objects")] public float checkCircleDistance;
	[Tooltip("Circle radius to check for objects")]  public float checkCircleRadius;
	public float grabAngleTolerance;

	[Space]
	[Header("UI")]
	public Vector3 uiOffset;
    

    Vector3 speedVector;
	float accelerationTimer;
	Vector3 lastVelocity;
	Vector3 input;
    Quaternion turnRotation;
    float distance;
	Quaternion steerTarget;

    [System.NonSerialized] public Interactable grabbedObject;
	Interactable canInteract;
	private float steerTimer;
	public float steerTimerLimit = .2f;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		actionText = actionUI.GetComponentInChildren<Text>();
		actionUI.SetActive(false);
		grabbedActionText = actionUI.GetComponentInChildren<Text>();
		grabbedActionUI.SetActive(false);
	}

	private void Start()
	{
		self.position = SpawnPoint.instance.transform.position;
	}

	// Update is called once per frame
	void Update()
    {
		CheckForActions();
        GetInput();

		GrabbedInteractUI();


		anim.SetFloat("MoveSpeed", walkAnimationSpeedCurve.Evaluate(speed));
    }

	void GrabbedInteractUI()
	{
		if (grabbedObject != null && grabbedObject.parameters.activationType == ActivationType.Handheld)
		{
			grabbedActionUI.SetActive(true);
			grabbedActionText.text = "(" + actionKey + ") Use: " + grabbedObject.parameters.objectName;
		}
		else
		{
			grabbedActionUI.SetActive(false);
		}
	}


	private void FixedUpdate()
    {
		CheckMoveState();
		if (moveState != MoveState.Steer)
		{
			if (input.magnitude != 0)
			{
				accelerationTimer += Time.fixedDeltaTime;
				Rotate();
				Accelerate();
			}
			else
			{
				accelerationTimer = 0;
			}
			Move();
		}
		else
		{
			Steer();
		}

		if (steerTimer > steerTimerLimit || steerTimer == 0)
			lastVelocity = body.velocity.normalized;

	}

	#region Input
	void GetInput()
    {
		if (HasGamepad())
		{
			GamepadInput();
		}
		else
		{
			KeyboardInput();
		}
	}

    void GamepadInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        input = input.normalized * ((input.magnitude - deadzone) / (1 - deadzone));

		// if (Input.GetKeyDown(grabKey))
		if (Input.GetButtonDown("Grab"))
		{
			print("Grab");
			Grab();
		}
		//if (Input.GetKeyDown(actionKey))
		if (Input.GetButtonDown("Action"))
		{
			print("Activate");
			ActivateObject();
		}
	}

    void KeyboardInput()
    {
		// if (Input.GetKeyDown(grabKey))
		if (Input.GetButtonDown("Grab"))
		{
			print("Grab");
            Grab();
        }
		//if (Input.GetKeyDown(actionKey))
		if (Input.GetButtonDown("Action"))
		{
			print("Activate");
			ActivateObject();
		}

        int _horDir = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _horDir--;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _horDir++;
        }

        int _vertDir = 0;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _vertDir--;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _vertDir++;
        }
		if ((Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)))
		{
			if (steerTimer == 0)
			{
				lastVelocity = body.velocity;
			}
			steerTimer += Time.deltaTime;
		}
		else
		{
			steerTimer = 0;
		}
        input = new Vector3(_horDir, 0, _vertDir);
        input.Normalize();
    }

    bool HasGamepad()
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region Movement
	
	void CheckMoveState()
	{
		if (Vector3.Dot(input, lastVelocity) < -0.8f && moveState != MoveState.Steer && speed >= steerThresholdSpeed * maxSpeed)
		{
			steerTarget = Quaternion.Euler(0, Mathf.Atan2(input.x, input.z) * 180 / Mathf.PI, 0);
			print("Start steeering");
			body.drag = steerDrag;
			moveState = MoveState.Steer;
            anim.SetInteger("EnumState", 2);
            Vector3 positionSpawnParticleSteer = self.position + self.forward + (self.up*-0.6f);
            Vector3 eulerRotationSpawnParticleSteer = self.rotation.eulerAngles + new Vector3(-90, -90, -45);
            GameObject _steerParticle = Instantiate(steerParticlesPrefab, positionSpawnParticleSteer, Quaternion.Euler(eulerRotationSpawnParticleSteer));
            Destroy(_steerParticle, 1.5f);
            myAudioSource.PlayOneShot(steerClip);

        }
		else if (body.velocity.magnitude <= minWalkSpeed)
		{
			if (moveState != MoveState.Idle)
			{
				body.velocity = Vector3.zero;
			}
			body.drag = idleDrag;
			moveState = MoveState.Idle;
            anim.SetInteger("EnumState", 0);
        }
		else if (moveState != MoveState.Steer)
		{
			if (input == Vector3.zero && (steerTimer > steerTimerLimit || steerTimer == 0))
			{
				body.drag = idleDrag;
			}
			else
			{
				body.drag = movingDrag;
			}
			moveState = MoveState.Walk;
            anim.SetInteger("EnumState", 1);
        }
	}

    void Rotate()
    {
        turnRotation = Quaternion.Euler(0, Mathf.Atan2(input.x, input.z) * 180 / Mathf.PI, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, turnRotation, turnSpeed);
    }
	void Steer()
	{
		transform.rotation = Quaternion.Slerp(transform.rotation, steerTarget, turnSpeed);
		print("Steering");
	}

    void Accelerate()
    {
        body.AddForce(input * (accelerationCurve.Evaluate(body.velocity.magnitude/maxSpeed) * maxAcceleration), ForceMode.Acceleration);
        body.drag = movingDrag;
    }

    void Move()
    {
        body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
		speed = body.velocity.magnitude;
    }
    #endregion

    #region Actions
	void CheckForActions()
	{
		Collider[] objectsNear = Physics.OverlapSphere(self.position + self.forward * checkCircleDistance, 5);

		canInteract = null;
		if (grabbedObject == null)
		{
			if (objectsNear.Length > 0)
			{
				List<Interactable> InteractablesNear = FilteredObjects(objectsNear, Filter.Interactable);
				if (InteractablesNear.Count > 0)
				{
					canInteract = GetNearestInFront(InteractablesNear);
				}
			}
		}
		UpdateInteractUI();
	}

	void UpdateInteractUI()
	{
		if (canInteract == null)
		{
			actionUI.SetActive(false);
		}
		else
		{
			//print("Object: " + canInteract + " has parameters: " + canInteract.parameters);
			if (canInteract.parameters.pickUp)
			{
				actionUI.SetActive(true);
				
				actionText.text = "(" + grabKey + ") GRAB: " + canInteract.parameters.objectName;
			}
			else if (canInteract.parameters.activationType == ActivationType.Proximity)
			{
				actionUI.SetActive(true);
				actionText.text = "(" + actionKey + ") ACTIVATE: " + canInteract.parameters.objectName;
			}
			else
			{
				actionUI.SetActive(false);
			}
			actionUI.transform.position = WorldToUIPosition(canInteract.transform.position) + uiOffset;
		}
	}

	Vector3 WorldToUIPosition(Vector3 _position)
	{
		Vector3 _UIPos = Camera.main.WorldToScreenPoint(_position);
		return _UIPos;
	}

	void Grab()
    {
        //Collider[] objectsGrab = Physics.OverlapSphere(self.position + self.forward * checkCircleDistance, checkCircleRadius);
		
        if ( grabbedObject == null)
        {
     //       if (objectsGrab.Length > 0)
     //       {
     //           List<Interactable> grabbableObjects = FilteredObjects(objectsGrab, Filter.Grab);
     //           if (grabbableObjects.Count > 0)
     //           {
     //               grabbedObject = GetNearestInFront(grabbableObjects);
					//grabbedObject.GetGrabbed(holdPoint);
     //               GameObject _grabParticlesRef = Instantiate(grabParticlesPrefab, holdPoint.position, Quaternion.identity, holdPoint);
     //               Destroy(_grabParticlesRef, 1);
     //               myAudioSource.PlayOneShot(grabClip);
     //           }
     //       }
			if (canInteract != null && canInteract.GetComponent<Interactable>().parameters.pickUp)
			{
				grabbedObject = canInteract;
				grabbedObject.GetGrabbed(holdPoint);
				GameObject _grabParticlesRef = Instantiate(grabParticlesPrefab, holdPoint.position, Quaternion.identity, holdPoint);
				Destroy(_grabParticlesRef, 1);
				myAudioSource.PlayOneShot(grabClip);
			}
		}
        else
        {
			grabbedObject.GetDropped();
            grabbedObject = null;
            GameObject _dropParticlesRef = Instantiate(dropParticlesPrefab, holdPoint.position, Quaternion.identity);
            Destroy(_dropParticlesRef, 1);
            myAudioSource.PlayOneShot(dropClip);
        }
    }

	void ActivateObject()
	{
		if (grabbedObject != null && grabbedObject.parameters.activationType == ActivationType.Handheld)
		{
			//grabbedObject.Activate();
			switch (grabbedObject.parameters.objectName)
			{
				case "Bat":
					anim.SetTrigger("SwingTrigger");
					break;

				default:
					grabbedObject.Activate();
					break;
			}
		}
		else
		{
			//Collider[] objectsActivate = Physics.OverlapSphere(self.position + self.forward * checkCircleDistance, checkCircleRadius);
			//if (objectsActivate.Length > 0)
			//{
			//	List<Interactable> activableObjects = FilteredObjects(objectsActivate, Filter.Activate);
			//	if (activableObjects.Count > 0)
			//	{
			//		GetNearestInFront(activableObjects).Activate();
			//	}
			//}
			if (canInteract != null && canInteract.GetComponent<Interactable>().parameters.activationType == ActivationType.Proximity)
			{
				canInteract.Activate();
			}
		}
	}

	List<Interactable> FilteredObjects(Collider[] _objects, Filter _filter)
	{
		List<Interactable> filteredObjects = new List<Interactable>();
		
		switch (_filter)
		{
			case Filter.Interactable:
				for (int i = 0; i < _objects.Length; i++)
				{
					if (_objects[i].tag == "Interactable")
					{
						filteredObjects.Add(_objects[i].GetComponent<Interactable>());
					}
				}
				break;
			case Filter.Grab:
				for (int i = 0; i < _objects.Length; i++)
				{
					if (_objects[i].tag == "Interactable" && 
						_objects[i].GetComponent<Interactable>().parameters.pickUp)
					{
						filteredObjects.Add(_objects[i].GetComponent<Interactable>());
					}
				}
				break;
			case Filter.Activate:
				for (int i = 0; i < _objects.Length; i++)
				{
					if (_objects[i].tag == "Interactable" && 
						_objects[i].GetComponent<Interactable>().parameters.activationType == ActivationType.Proximity)
					{
						filteredObjects.Add(_objects[i].GetComponent<Interactable>());
					}
				}
				break;
		}
		
		return filteredObjects;
	}
	
	//TO OPTIMIZE
    Interactable GetNearestInFront(List<Interactable> _objects)
    {
		List<Interactable> inFrontObjects = new List<Interactable>();
		float minAngle = Mathf.Infinity;
		for (int i = 0; i < _objects.Count; i++)
		{
			Vector3 directionToObject = _objects[i].self.position - self.position;
			float angle = Vector3.Angle(directionToObject, self.forward);
			if (Vector3.Angle(directionToObject, self.forward) < minAngle)
			{
				minAngle = angle;
			}
		}
		for (int i = 0; i < _objects.Count; i++)
		{
			Vector3 directionToObject = _objects[i].self.position - self.position;
			float angle = Vector3.Angle(directionToObject, self.forward);
			if (angle < minAngle + grabAngleTolerance)
			{
				inFrontObjects.Add(_objects[i]);
			}
		}

		float minDist = Mathf.Infinity;
        int minIndex = -1;
        for (int i = 0; i < inFrontObjects.Count; i++)
        {
            if (Vector3.Distance(self.position, inFrontObjects[i].self.position) < minDist)
            {
                minDist = Vector3.Distance(self.position, inFrontObjects[i].self.position);
                minIndex = i;
            }
        }
        return inFrontObjects[minIndex];
    }

	#endregion
}
