using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : Interactable {

	public override void Activate()
	{
		base.Activate();
		if (!burning)
		{
			Burn(gameObject);
			fireScript.canSpread = true;
		}
		else Deactivate();
	}

	public override void Deactivate()
	{
		StopBurning();
	}

}
