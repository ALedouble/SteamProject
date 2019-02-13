using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolButton : Interactable {

    public Animator TrapaulinAnim;

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
            TrapaulinAnim.SetBool("OpenBool", false);

        }
	}

	public override void Deactivate()
	{
		base.Deactivate();
		activated = false;
        TrapaulinAnim.SetBool("OpenBool", true);
    }
}
