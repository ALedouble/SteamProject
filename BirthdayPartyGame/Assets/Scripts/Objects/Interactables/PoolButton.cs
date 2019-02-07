using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolButton : Interactable {

	public GameObject pool;

	public override void Activate()
	{
		base.Activate();
		if (activated)
		{
			Deactivate();
		}
		else
		{
			activated = true;
			pool.SetActive(false);
		}
	}

	public override void Deactivate()
	{
		base.Deactivate();
		activated = false;
		pool.SetActive(true);
	}
}
