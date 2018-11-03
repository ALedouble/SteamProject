using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : Interactable {

	public override void Activate()
	{
		base.Activate();
		print("BOOM BOOM BOOM");
	}

	public override void Die()
	{
		print("ZOING");
	}

}
