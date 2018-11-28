using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : Interactable {

	public Material matOff;
	public Material matOn;
	Renderer rend;

	public void Start()
	{
		rend = GetComponent<Renderer>();
	}

	public override void Activate()
	{
		base.Activate();
		rend.material = matOn;
	}

	public override void Deactivate()
	{
		rend.material = matOff;
	}

}
