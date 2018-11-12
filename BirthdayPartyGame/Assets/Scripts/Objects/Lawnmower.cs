using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lawnmower : Interactable {

	public float speed = 2;
	public float maxSpeed = 30;
	public float gravityAdded = 3;

	public override void Activate()
	{
		base.Activate();
		activated = true;
	}

	private void Update()
	{
		if (activated)
		{
			body.AddForce(self.forward * speed, ForceMode.VelocityChange);
			body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
		}
	}

	private void FixedUpdate()
	{
		if (Mathf.Abs(body.velocity.y) > 1 && activated)
		{
			print("Going down");
			body.AddForce(Vector3.down * gravityAdded, ForceMode.Acceleration);
		}
	}

}
