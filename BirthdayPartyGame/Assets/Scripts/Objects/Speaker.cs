using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : Interactable {

    [Space]
	public AudioSource levelAudioSource;
	public AudioClip firstMusic;
	public AudioClip secondMusic;
    public AudioClip levelMusic;
    [Space]
    public GameObject explosionParticlePrefab;
    public GameObject smokeParticlePrefab;
    public Transform explosionTransform;
    [Space]
    public Animator myAnim;

    protected override void Start()
    {
		base.Start();
        levelAudioSource.clip = levelMusic;
        levelAudioSource.volume = 0.5f;
        levelAudioSource.Play();
    }

    public override void Activate()
	{
		base.Activate();
		if (!activated)
		{
            levelAudioSource.Stop();
            levelAudioSource.clip = firstMusic;
            levelAudioSource.volume = .8f;
            levelAudioSource.Play();
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
        levelAudioSource.Stop();
        levelAudioSource.clip = secondMusic;
        levelAudioSource.Play();
        activated = false;
        myAnim.SetTrigger("HardTrigger");

    }

	public override void Die()
	{
        Instantiate(explosionParticlePrefab, explosionTransform.position, Quaternion.identity);
        Instantiate(smokeParticlePrefab, explosionTransform.position, Quaternion.Euler(-90, 0, 0), transform);
        canActivate = false;
        levelAudioSource.Stop();
        levelAudioSource.clip = levelMusic;
        levelAudioSource.Play();
        myAnim.SetTrigger("NoMusicTrigger");
        print("noMusic");

    }

}
