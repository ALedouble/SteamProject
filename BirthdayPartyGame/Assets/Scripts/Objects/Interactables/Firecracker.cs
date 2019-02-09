using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firecracker : Interactable {

	bool chargingExplosion;
	public float explosionCooldown = 3;
	float explosionTimer;

	public GameObject explosion;
	public float explosionSize = 2.5f;

	// Update is called once per frame
	void Update () {
		if (burning && !chargingExplosion)
		{
			chargingExplosion = true;
		}
		else if (!burning && chargingExplosion)
		{
			chargingExplosion = false;
			explosionTimer = 0;
		}

		if (chargingExplosion)
		{
			if (explosionTimer < explosionCooldown)
			{
				explosionTimer += Time.deltaTime;
			}
			else
			{
				Die();
			}
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
}
