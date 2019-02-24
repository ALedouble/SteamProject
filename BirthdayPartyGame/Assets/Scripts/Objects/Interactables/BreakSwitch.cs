using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakSwitch : Interactable {

	public Animator gantryAnim;

	public override void Die()
	{
		Activate();
	}

	public override void Activate()
	{
		base.Activate();
		if (!canActivate) return;
		gantryAnim.SetTrigger("Open");
		canActivate = false;
	}

}
