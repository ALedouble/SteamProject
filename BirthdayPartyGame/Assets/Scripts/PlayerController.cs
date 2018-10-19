using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("Components")]
	public Rigidbody body;
	public Transform holdPoint;

	[Space]
	[Header("Inputs")]
	public float deadzone = 0.2f;

	[Space]
	[Header("Controls")]
	public float maxSpeed = 10;
	//[Range(0.01f, 1f)]
	public float acceleration = .2f;
	//[Range(0.01f, 1f)]
	public float movingDrag = .4f;
	public float idleDrag = .4f;
	[Range(0.01f, 1f)]
	public float turnSpeed = .25f;

	Vector3 speedVector;
	float horSpeed;
	float vertSpeed;
	Vector3 input;
	Quaternion turnRotation;

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
		if (input.magnitude != 0)
		{
			Rotate();
			Accelerate();
		}
		else if (body.velocity != Vector3.zero)
		{
			StopMoving();
		}
		Move();
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
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			Grab();
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
	void Rotate()
	{
		turnRotation = Quaternion.Euler(0, Mathf.Atan2(input.x, input.z) * 180 / Mathf.PI, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, turnRotation, turnSpeed);
	}

	void Accelerate()
	{
		body.AddForce(input * acceleration, ForceMode.Acceleration);
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
			body.angularVelocity = Vector3.Lerp(body.angularVelocity, Vector3.zero, acceleration);
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
		//Check for pick up
		//Pick up
	}
	#endregion
}
