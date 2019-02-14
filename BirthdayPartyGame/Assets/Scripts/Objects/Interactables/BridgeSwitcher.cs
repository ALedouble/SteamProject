using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSwitcher : Interactable {

    public Animator bridgeBarrierAnim;
    public bool opened;
    public AudioSource myAudioSourceGate;
    public AudioClip openingClip;
    public AudioClip closingClip;
    public AudioSource myAudioSourceButton;
    public AudioClip toggleButtonClip;

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
            myAudioSourceGate.PlayOneShot(openingClip);
            myAudioSourceButton.PlayOneShot(toggleButtonClip);
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
        myAudioSourceGate.PlayOneShot(closingClip);
        myAudioSourceButton.PlayOneShot(toggleButtonClip);
        base.Deactivate();
	}
}
