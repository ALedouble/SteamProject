using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinata : Interactable {

	public GameObject containedObject;

	public override void Die()
	{
		base.Die();

		if (containedObject != null)
			Instantiate(containedObject, transform.position, Quaternion.identity);
	}

}
