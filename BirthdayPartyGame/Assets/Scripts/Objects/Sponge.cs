using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : Interactable {

	public override void Activate()
	{
		base.Activate();
		if (!wet)
		{
			GetWet();
			waterScript.canWet = true;
		}
		else Deactivate();
	}

	public override void Deactivate()
	{
		base.Deactivate();
		if (wet)
		{
			wet = false;
			GetComponent<Water>().enabled = false;
			myWaterParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		}
	}

}
