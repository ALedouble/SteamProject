using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : Interactable {

	public override void Burn()
	{
		base.Burn();
		Die();
	}

	public override void Die()
	{
		if (DieEvent != null)
			DieEvent(this);
	}
}
