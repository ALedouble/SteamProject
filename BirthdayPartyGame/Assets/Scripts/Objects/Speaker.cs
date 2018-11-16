using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : Interactable {

	public AudioSource myAudioSource;
	public AudioClip firstMusic;
	public AudioClip secondMusic;
    [Space]
    public GameObject explosionParticlePrefab;
    public Transform explosionTransform;

	public override void Activate()
	{
		base.Activate();
		if (!activated)
		{
            myAudioSource.Stop();
            myAudioSource.PlayOneShot(firstMusic);
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
        myAudioSource.Stop();
        myAudioSource.PlayOneShot(secondMusic);
		activated = false;
	}

	public override void Die()
	{
        Instantiate(explosionParticlePrefab, explosionTransform.position, Quaternion.identity);
		canActivate = false;
        myAudioSource.Stop();
	}

}
