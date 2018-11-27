using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Interactable {

	public float shootForce = 5;




	void Start() {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player")
		{
			GetShot(collision.contacts[0].point, collision.rigidbody.velocity);
		}
	}

	void GetShot(Vector3 _impactPoint, Vector3 otherSpeed)
	{
		Vector3 direction = self.position - _impactPoint;
		body.AddForce(direction.normalized * shootForce + otherSpeed/2, ForceMode.VelocityChange);
	}

}
