using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

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
    public float dotTolerance;

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

    [Space]
    [Header("TestNewGrab")]
    List<Interactable> listOfInteractables = new List<Interactable>();
    public Transform pointRef;
    Vector3 velocityLateUpdate;

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
		grabbedActionText = grabbedActionUI.GetComponentInChildren<Text>();
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
		if (grabbedObject != null)
		{
			grabbedActionUI.SetActive(true);
			grabbedActionText.text = grabbedObject.parameters.objectName;
			if (grabbedObject.parameters.activationType == ActivationType.Handheld)
			{
				grabbedActionText.text += ": X to use";
			}
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
			Grab(canInteract);
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
            Grab(canInteract);
        }
		//if (Input.GetKeyDown(actionKey))
		if (Input.GetButtonDown("Action"))
		{
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
        CleanInteractableList();
        canInteract = null;
		if (grabbedObject == null)
		{
			if (listOfInteractables.Count > 0)
			{
				canInteract = GetNearestInFront(listOfInteractables);
			}
		}
		UpdateInteractUI();
	}

    void CleanInteractableList()
    {
        for (int i = 0; i < listOfInteractables.Count; i++)
        {
            if(listOfInteractables[i] == null)
            {
                listOfInteractables.Remove(listOfInteractables[i]);
            }
        }
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

	public void Grab(Interactable _toGrab)
    {		
        if (grabbedObject == null)
        {
			if (_toGrab != null && _toGrab.GetComponent<Interactable>().parameters.pickUp)
			{
				grabbedObject = _toGrab;
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
			switch (grabbedObject.parameters.objectName)
			{
				case "Bat":
					anim.SetTrigger("SwingTrigger");
					break;

                case "Water Pistol":
                    anim.SetTrigger("ShootTrigger");
                    grabbedObject.Activate();
                    break;

                default:
					grabbedObject.Activate();
					break;
			}
		}
		else
		{
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
						print("Checking filter interactable");
						filteredObjects.Add(_objects[i].GetComponent<Interactable>());
					}
				}
				break;
			case Filter.Grab:
				for (int i = 0; i < _objects.Length; i++)
				{
					if (_objects[i].tag == "Interactable" && 
						_objects[i].GetComponent<Interactable>().parameters.pickUp && !_objects[i].GetComponent<Interactable>().isGrabbed)
					{
						print("Checking filter grab");
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
						print("Checking filter activate");
						filteredObjects.Add(_objects[i].GetComponent<Interactable>());
					}
				}
				break;
		}
		for (int i = 0; i < filteredObjects.Count; i++)
		{
			print("Filtered objects: " + filteredObjects[i].name);
		}
		return filteredObjects;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interactable")
        {
			print("Seen an interactable");
            var needToBeFiltered = new Collider[] {other};
            if(FilteredObjects(needToBeFiltered, Filter.Grab).Count > 0 || FilteredObjects(needToBeFiltered, Filter.Activate).Count > 0)
            {
                listOfInteractables.Add(other.GetComponent<Interactable>());
                print(listOfInteractables.Count);
            }            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            var needToBeFiltered = new Collider[] { other };
            if (FilteredObjects(needToBeFiltered, Filter.Grab).Count > 0 || FilteredObjects(needToBeFiltered, Filter.Activate).Count > 0)
            {
                listOfInteractables.Remove(other.GetComponent<Interactable>());
            }

        }
    }
    
    Interactable GetNearestInFront(List<Interactable> _objects)
    {
        if (listOfInteractables.Count > 0)
        {
            float p = Mathf.Infinity;
            Interactable newI = null;
            for (int i = 0; i < listOfInteractables.Count; i++)
            {
                if(Vector3.Distance(pointRef.position, listOfInteractables[i].transform.position) < p)
                {
                    p = Vector3.Distance(pointRef.position, listOfInteractables[i].transform.position);
                    newI = listOfInteractables[i];
                }
            }
            return newI;
        }
        else
        {
            return null;
        }
    }

    #endregion
}
