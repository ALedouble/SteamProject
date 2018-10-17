using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("Components")]
	public Rigidbody body;

	[Space]
	[Header("Inputs")]
	public float deadzone = 0.2f;

	[Space]
	[Header("Controls")]
	public float maxSpeed = 10;
	public float acceleration = .2f;
	public float turnSpeed = .25f;
	Vector3 speedVector;
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
		int _horSpeed = 0;
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			_horSpeed--;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			_horSpeed++;
		}
		int _vertSpeed = 0;
		if (Input.GetKey(KeyCode.DownArrow))
		{
			_vertSpeed--;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			_vertSpeed++;
		}
		input = new Vector3(_horSpeed, 0, _vertSpeed);
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
		speedVector = Vector3.Lerp(input * speedVector.magnitude, input * maxSpeed, acceleration);
	}

	void Move()
	{
		body.velocity = speedVector;
	}

	void StopMoving()
	{
		print("Stop moving");
		if (body.velocity.magnitude >= .5f)
		{
			speedVector = Vector3.Lerp(body.velocity, Vector3.zero, acceleration);
			body.angularVelocity = Vector3.Lerp(body.angularVelocity, Vector3.zero, acceleration*2);
		}
		else
		{
			speedVector = Vector3.zero;
			body.angularVelocity = Vector3.zero;
		}
	}
	#endregion
}
