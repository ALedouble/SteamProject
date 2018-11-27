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
		canBreak = true;
		canActivate = false;
		myAudioSource.PlayOneShot(batteSwingClip);
	}

	public override void Deactivate()
	{
		base.Deactivate();
		canBreak = false;
		canActivate = true;
	}
}
