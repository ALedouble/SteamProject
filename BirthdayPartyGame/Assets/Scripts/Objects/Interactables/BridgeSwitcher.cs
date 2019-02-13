using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSwitcher : Interactable {

    public Animator bridgeBarrierAnim;
    public bool opened;
    public AudioSource myAudioSource;
    public AudioClip openingClip;
    public AudioClip closingClip;

    protected override void Start()
    {
        base.Start();
    }

    public override void Activate()
    {
        base.Activate();
        if (!activated)
        {
            activated = true;
            myAudioSource.PlayOneShot(openingClip);
            bridgeBarrierAnim.SetTrigger("ToggleTrigger");
            opened = true;
        }
        else
        {
            Deactivate();
            activated = false;
        }
    }

    public override void Deactivate()
    {
        
        bridgeBarrierAnim.SetTrigger("ToggleTrigger");
        opened = false;
        myAudioSource.PlayOneShot(closingClip);
        base.Deactivate();
	}
}
