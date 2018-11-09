using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lawnmower : Interactable {

	public float speed = 2;
	public float maxSpeed = 30;

	public override void Activate()
	{
		base.Activate();
		activated = true;
	}

	private void Update()
	{
		if (activated)
		{
			body.AddForce(self.forward * speed, ForceMode.Acceleration);
			body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
		}
	}

}
