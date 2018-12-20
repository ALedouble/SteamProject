using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : Interactable {

    [Space]
	public AudioSource levelAudioSource;
	public AudioClip firstMusic;
	public AudioClip secondMusic;
    public AudioClip levelMusic;
    public AnimationCurve comingBackMusicCurve;
    public float secondMusicVolume;
    public float firstMusicVolumeBeforeDeath;
    public float firstMusicVolumeAfterDeath;
    public float timeforMusicToComeBack;
    float musicVolumeAscending;
    [Space]
    public GameObject explosionParticlePrefab;
    public GameObject smokeParticlePrefab;
    public Transform explosionTransform;
    [Space]
    public Animator myAnim;

    protected override void Start()
    {
		base.Start();
		levelAudioSource = GameObject.Find("LevelAudioSource").GetComponent<AudioSource>();
        levelAudioSource.clip = firstMusic;
        levelAudioSource.volume = firstMusicVolumeBeforeDeath;
        levelAudioSource.Play();
        activated = true;
        myAnim.SetTrigger("PopTrigger");
    }

    public override void Activate()
	{
		base.Activate();
		if (!activated)
		{
            levelAudioSource.Stop();
            levelAudioSource.clip = firstMusic;
            levelAudioSource.volume = firstMusicVolumeBeforeDeath;
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
        levelAudioSource.volume = secondMusicVolume;
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
        levelAudioSource.volume = 0;
        StopCoroutine(MusicComingBack());
        StartCoroutine(MusicComingBack());
        myAnim.SetTrigger("NoMusicTrigger");
    }

    IEnumerator MusicComingBack()
    {
        musicVolumeAscending += Time.deltaTime / timeforMusicToComeBack;
        levelAudioSource.volume = comingBackMusicCurve.Evaluate(musicVolumeAscending);
        yield return new WaitForSeconds(Time.deltaTime);
        if (musicVolumeAscending < firstMusicVolumeAfterDeath)
        {
            StartCoroutine(MusicComingBack());
        }
    }

}
