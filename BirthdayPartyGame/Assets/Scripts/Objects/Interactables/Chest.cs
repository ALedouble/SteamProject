using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {

    public AttractionCircleV2 myAttractionCircle;
    public int minScore;
    public int maxScore;
    public Animator myAnim;
    public ParticleSystem myParticleSystem;
    public AudioSource myAudioSource;
    public AudioClip openingClip;
    public AudioClip closingClip;
    public AudioClip shiningClip;

    protected override void Start()
    {
        base.Start();
    }

    public override void Activate()
    {
        base.Activate();
        if (!activated)
        {
            myAttractionCircle.ChangeScore(maxScore);
            myAnim.SetBool("OpenBool", true);
            myParticleSystem.Play();
            myAudioSource.PlayOneShot(openingClip);
            Invoke("PlayShineClip", 0.5f);
            activated = true;
        }
        else
        {
            Deactivate();
        }
    }

    void PlayShineClip()
    {
        if (activated)
        {
            myAudioSource.clip = shiningClip;
            myAudioSource.Play();
            myAudioSource.loop = true;
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();
        myAttractionCircle.ChangeScore(minScore);
        myAnim.SetBool("OpenBool", false);
        myParticleSystem.Clear();
        myParticleSystem.Stop();
        myAudioSource.Stop();
        myAudioSource.clip = null;
        myAudioSource.loop = false;
        myAudioSource.PlayOneShot(closingClip);
        activated = false;
    }
}
