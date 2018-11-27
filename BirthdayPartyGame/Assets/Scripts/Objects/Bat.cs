using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Interactable
{

	public float swingDuration = 1;
    public AudioSource myAudioSource;
    public AudioClip batteSwingClip;

	public override void Activate()
	{
		base.Activate();
		//StartCoroutine(BatSwing());
		canBreak = true;
		canActivate = false;
		print("Start swinging");
		myAudioSource.PlayOneShot(batteSwingClip);
	}

	public override void Deactivate()
	{
		base.Deactivate();
		print("Stop swinging");
		canBreak = false;
		canActivate = true;
	}

	//IEnumerator BatSwing()
	//{
	//	canBreak = true;
	//	canActivate = false;
	//	print("Start swinging");
	//       myAudioSource.PlayOneShot(batteSwingClip);

	//       yield return new WaitForSeconds(swingDuration);

	//	canBreak = false;
	//	print("Stop swinging");
	//	canActivate = true;
	//}
}
