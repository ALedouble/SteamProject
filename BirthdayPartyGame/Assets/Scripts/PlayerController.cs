using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveState
{
	Idle,
	Walk,
	Steer
}

public enum Filter
{
	Grab,
	Activate
}

public class PlayerController : MonoBehaviour {

    [Header("Components")]
    public Rigidbody body;
    public Transform holdPoint;

    [Space]
    [Header("Inputs")]
    public float deadzone = 0.2f;

	[Space]
	[Header("Controls")]
	public MoveState moveState;
    public float maxSpeed = 10;
	public float maxAcceleration = 10;
	public AnimationCurve accelerationCurve;
    public float movingDrag = .4f;
    public float idleDrag = .4f;
    [Range(0.01f, 1f)]
    public float turnSpeed = .25f;

    [Space]
    [Header("Grab")]
    public Transform self;

    Vector3 speedVector;
	float accelerationTimer;
	Vector3 lastVelocity;
	Vector3 input;
    Quaternion turnRotation;
    float distance;

    Interactable grabbedObject;

	public float steerDeceleration;

	// Use this for initialization
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
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

		CheckMoveState();
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
    }

    void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Grab();
        }
		if (Input.GetKeyDown(KeyCode.A))
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
		if (Vector3.Dot(input, lastVelocity) < -0.8f && moveState != MoveState.Steer)
		{
			transform.rotation = Quaternion.Euler(0, Mathf.Atan2(input.x, input.z) * 180 / Mathf.PI, 0);
			body.drag = steerDeceleration;
			moveState = MoveState.Steer;
		}
		else if (body.velocity.magnitude <= 1f)
		{
			body.drag = idleDrag;
			moveState = MoveState.Idle;
		}
		else if (moveState != MoveState.Steer)
		{
			body.drag = movingDrag;
			moveState = MoveState.Walk;
		}
	}

    void Rotate()
    {
        turnRotation = Quaternion.Euler(0, Mathf.Atan2(input.x, input.z) * 180 / Mathf.PI, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, turnRotation, turnSpeed);
    }

    void Accelerate()
    {
        body.AddForce(input * (accelerationCurve.Evaluate(body.velocity.magnitude/maxSpeed) * maxAcceleration), ForceMode.Acceleration);
        body.drag = movingDrag;
    }

    void Move()
    {
        body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
    }
    #endregion

    #region Actions
    void Grab()
    {
        Collider[] objectsGrab = Physics.OverlapSphere(self.position, 5);
		
        if ( grabbedObject == null)
        {
            if (objectsGrab.Length > 0)
            {
                List<Interactable> grabbableObjects = FilteredObjects(objectsGrab, Filter.Grab);
                if (grabbableObjects.Count > 0)
                {
                    grabbedObject = GetNearestInFront(grabbableObjects);
					grabbedObject.GetGrabbed(holdPoint);
                }
            }
        }
        else
        {
			grabbedObject.GetDropped();
            grabbedObject = null;
        }
    }

	void ActivateObject()
	{
		if (grabbedObject != null && grabbedObject.parameters.activationType == ActivationType.Handheld)
		{
			grabbedObject.Activate();
		}
		else
		{
			Collider[] objectsActivate = Physics.OverlapSphere(self.position, 5);
			if (objectsActivate.Length > 0)
			{
				List<Interactable> activableObjects = FilteredObjects(objectsActivate, Filter.Activate);
				if (activableObjects.Count > 0)
				{
					GetNearestInFront(activableObjects).Activate();
				}
			}
		}
	}

	List<Interactable> FilteredObjects(Collider[] _objects, Filter _filter)
	{
		List<Interactable> filteredObjects = new List<Interactable>();
		
		switch (_filter)
		{
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
			if (angle < minAngle + 1)
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
