using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Interactable
{

	public float swingDuration = 1;

	public override void Activate()
	{
		base.Activate();
		if (canActivate)
		{
			StartCoroutine(BatSwing());
		}
	}

	IEnumerator BatSwing()
	{
		canBreak = true;
		canActivate = false;
		print("Start swinging");

		yield return new WaitForSeconds(swingDuration);

		canBreak = false;
		print("Stop swinging");
		canActivate = true;
	}
}
