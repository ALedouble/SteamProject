using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lawnmower : Interactable {

	public float speed = 2;
	public float maxSpeed = 30;
	public float gravityAdded = 3;
	public float damageZoneHeight = .3f;
	public float pushAwayForce = 20;

	public override void Activate()
	{
		base.Activate();
		activated = true;
	}

	public override void Deactivate()
	{
		base.Deactivate();
		activated = false;
	}

	private void FixedUpdate()
	{
		if (activated)
		{
			body.mass = 50;
			body.AddForce(self.forward * speed, ForceMode.Acceleration);
			body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
			if (Mathf.Abs(body.velocity.y) > 1)
			{
				body.AddForce(Vector3.down * gravityAdded, ForceMode.Acceleration);
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		//if (activated && collision.rigidbody != null && !collision.rigidbody.isKinematic)
		//{
		//	StartCoroutine(WaitToDeactivate());
		//}
		if (activated)
		{
			if (collision.collider.tag == "Player")
			{
				PlayerController _player = collision.collider.GetComponent<PlayerController>();
				Vector3 _directionToPlayer = _player.self.position - self.position;
				int _lateralDirection = 0;
				if (Vector3.SignedAngle(self.forward, _directionToPlayer, Vector3.up) > 0)
				{
					_lateralDirection = 1;
				}
				else
				{
					_lateralDirection = -1;
				}
				Vector3 _direction = self.right * _lateralDirection;
				_player.body.AddForce(_direction * pushAwayForce, ForceMode.VelocityChange);
			}
			else if (collision.contacts[0].point.x >= self.position.x + damageZoneHeight)
			{
				StartCoroutine(WaitToDeactivate());
			}
		}
		
	}

	IEnumerator WaitToDeactivate()
	{
		yield return new WaitForSeconds(.1f);
		Deactivate();
	}

}
