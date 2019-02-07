using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : Interactable {

	private void OnTriggerEnter(Collider other)
	{
		gameObject.SetActive(false);
		print("Collided with: " + other);
	}
}
