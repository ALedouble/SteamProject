using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : Interactable {

    [Space]
	public AudioSource myAudioSource;
	public AudioClip firstMusic;
	public AudioClip secondMusic;
    [Space]
    public GameObject explosionParticlePrefab;
    public GameObject smokeParticlePrefab;
    public Transform explosionTransform;
    [Space]
    public Animator myAnim;

	public override void Activate()
	{
		base.Activate();
		if (!activated)
		{
            myAudioSource.Stop();
            myAudioSource.PlayOneShot(firstMusic);
			activated = true;
            myAnim.SetTrigger("PopTrigger");
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
        myAnim.SetTrigger("HardTrigger");

    }

	public override void Die()
	{
        Instantiate(explosionParticlePrefab, explosionTransform.position, Quaternion.identity);
        Instantiate(smokeParticlePrefab, explosionTransform.position, Quaternion.Euler(-90, 0, 0), transform);
        canActivate = false;
        myAudioSource.Stop();
        myAnim.SetTrigger("NoMusicTrigger");
        print("noMusic");

    }

}
