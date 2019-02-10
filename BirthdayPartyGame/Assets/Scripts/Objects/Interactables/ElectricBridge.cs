using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBridge : Interactable {

	public Animator anim;

	public override void Activate()
	{
		base.Activate();
		//transform.rotation = Quaternion.Euler(0, 90, 0);
		print("Move bridge");
		if (!activated)
		{
			Lower();
			activated = true;
		}
		else
		{
			Deactivate();
		}
	}

	public override void Deactivate()
	{
		base.Deactivate();
		Rise();
		activated = false;
	}

	void Rise()
	{
		anim.SetTrigger("Move");
		anim.speed = 1;
	}

	void Lower()
	{
		anim.SetTrigger("Move");
		anim.speed = -1;
	}

}
