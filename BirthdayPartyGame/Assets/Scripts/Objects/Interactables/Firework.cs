using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : Interactable, ILaunchable {

	public float canExplodeSpeedThreshold = 2;
	public GameObject explosion;
	public float explosionSize = 2.5f;
	

	private void OnCollisionEnter(Collision collision)
	{
		if (body == null) return;
		if (body.velocity.magnitude > canExplodeSpeedThreshold)
		{
			print("Collided with: " + collision.collider);
			Die();
		}
	}

	public override void Die()
	{
		base.Die();
		Explode();
	}

	void Explode()
	{
		Explosion newExplosion = Instantiate(explosion, self.position, Quaternion.identity).GetComponent<Explosion>();
		newExplosion.InitializeScale(explosionSize);
		//Die();
	}

	public void GetLaunched(Vector3 _direction, float _force)
	{
		if (body == null) body = GetComponent<Rigidbody>();

		body.AddForce(_direction * _force, ForceMode.VelocityChange);
	}

}
