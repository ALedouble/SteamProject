using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Interactable
{
	public float swingDuration = 1;
	Vector3[] initialScale;
	public float swingGrowFactor = 1.5f;
    public AudioSource myAudioSource;
    public AudioClip batteSwingClip;

	protected override void Start()
	{
		base.Start();
		initialScale = new Vector3[colliders.Length];
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i] != null)
			{
				BoxCollider box = colliders[i] as BoxCollider;
				initialScale[i] = box.size;
			}
		}
	}

	public override void Activate()
	{
		base.Activate();
		for (int i = 0; i < colliders.Length; i++)
		{
			BoxCollider box = colliders[i] as BoxCollider;
			box.size = initialScale[i] * swingGrowFactor;
		}
		canBreak = true;
		canActivate = false;
		myAudioSource.PlayOneShot(batteSwingClip);
	}

	public override void Deactivate()
	{
		base.Deactivate();
		for (int i = 0; i < colliders.Length; i++)
		{
			BoxCollider box = colliders[i] as BoxCollider;
			box.size = initialScale[i];
		}
		canBreak = false;
		canActivate = true;
	}
}
