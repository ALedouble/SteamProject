using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taser : Interactable {

	public override void Activate()
	{
		base.Activate();
		if (!electrified)
		{
			GetElectrified(null);
			electricityScript.canSpread = true;
			electricityScript.firstGeneration = true;
		}
		else Deactivate();
	}

	public override void Deactivate()
	{
		StopElectrified();
	}
}
