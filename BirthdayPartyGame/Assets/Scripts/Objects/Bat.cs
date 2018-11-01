using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Interactable
{

	public float swingDuration = 1;

	public override void Activate()
	{
		StartCoroutine(BatSwing());
	}

	IEnumerator BatSwing()
	{
		canBreak = true;
		print("Start swinging");
		yield return new WaitForSeconds(swingDuration);
		canBreak = false;
		print("Stop swinging");
	}
}
