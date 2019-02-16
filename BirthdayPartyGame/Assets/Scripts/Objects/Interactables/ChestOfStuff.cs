using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOfStuff : Interactable {

	public GameObject toSpawn;

	public override void Activate()
	{
		base.Activate();
		Interactable newStuff = Instantiate(toSpawn).GetComponent<Interactable>();
		newStuff.Initialize();
		PlayerController.instance.Grab(newStuff);
		//newStuff.GetGrabbed(PlayerController.instance.holdPoint);
	}
}
