using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveState
{
	Idle,
	Walk,
	Steer
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
    //[Range(0.01f, 1f)]
    //public float acceleration = .2f;
    //[Range(0.01f, 1f)]
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
			else //if (body.velocity != Vector3.zero)
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

    void StopMoving()
    {
        body.drag = idleDrag;
        if (body.velocity.magnitude >= .5f)
        {
            //body.angularVelocity = Vector3.Lerp(body.angularVelocity, Vector3.zero, acceleration);
        }
        else
        {
            body.angularVelocity = Vector3.zero;
        }
    }
    #endregion

    #region Actions
    void Grab()
    {
        Collider[] objectsGrab = Physics.OverlapSphere(self.position, 5);
        // Check Grab
            if ( grabbedObject == null)
            {
                if (objectsGrab.Length > 0)
                {
                    List<Interactable> grabbableObjects = GetGrab(objectsGrab);
                    if (grabbableObjects.Count > 0)
                    {
                        grabbedObject = GetNearest(grabbableObjects);
                        grabbedObject.transform.position = holdPoint.position;
						grabbedObject.transform.rotation = holdPoint.rotation;
                        grabbedObject.transform.parent = holdPoint;
                        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
            }
            else
            {
                grabbedObject.transform.parent = null;
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                grabbedObject = null;
            }
    }

    List<Interactable> GetGrab(Collider[] objectsGrab)
    {
        List<Interactable> pickUpObjects = new List<Interactable>();

        for (int i = 0; i < objectsGrab.Length; i++)
        {
            if (objectsGrab[i].tag == "Interactable" && objectsGrab[i].GetComponent<Interactable>().parameters.pickUp)
            {
                pickUpObjects.Add(objectsGrab[i].GetComponent<Interactable>());
            }
        }
        return pickUpObjects;
    }
	
    Interactable GetNearest(List<Interactable> grabbableObjects)
    {
        float minDist = Mathf.Infinity;
        int minIndex = -1;
        for (int i = 0; i < grabbableObjects.Count; i++)
        {
            if (Vector3.Distance(self.position, grabbableObjects[i].transform.position) < minDist)
            {
                minDist = Vector3.Distance(self.position, grabbableObjects[i].transform.position);
                minIndex = i;
            }
        }
        return grabbableObjects[minIndex];
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
				List<Interactable> activableObjects = GetActivate(objectsActivate);
				if (activableObjects.Count > 0)
				{
					GetNearest(activableObjects).Activate();
				}
			}
			
		}
	}

	List<Interactable> GetActivate(Collider[] objectsActivate)
	{
		List<Interactable> toActivateObjects = new List<Interactable>();

		for (int i = 0; i < objectsActivate.Length; i++)
		{
			if (objectsActivate[i].tag == "Interactable" && objectsActivate[i].GetComponent<Interactable>().parameters.activationType == ActivationType.Proximity)
			{
				toActivateObjects.Add(objectsActivate[i].GetComponent<Interactable>());
			}
		}
		return toActivateObjects;
	}

	#endregion
}
