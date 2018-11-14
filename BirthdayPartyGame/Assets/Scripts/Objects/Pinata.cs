using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinata : Interactable {

	public GameObject containedObject;
    public GameObject confettiParticlesPrefab;

	public override void Die()
	{
        GameObject _confettiParticlesRef = Instantiate(confettiParticlesPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(_confettiParticlesRef, 2.5f);
		base.Die();
		if (containedObject != null)
			Instantiate(containedObject, transform.position, Quaternion.identity);
	}

}
