using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : Interactable {

	public AudioSource source;
	public AudioClip firstMusic;
	public AudioClip secondMusic;

	public override void Activate()
	{
		base.Activate();
		print("BOOM BOOM BOOM");
		//if (!activated)
		//{
		//	source.PlayOneShot(firstMusic);
		//	activated = true;
		//}
		//else
		//{
		//	Deactivate();
		//}
	}

	public override void Deactivate()
	{
		base.Deactivate();
		source.PlayOneShot(secondMusic);
		activated = false;
	}

	public override void Die()
	{
		print("ZOING");
		canActivate = false;
		source.Stop();
	}

}
