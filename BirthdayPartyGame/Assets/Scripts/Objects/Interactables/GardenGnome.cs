using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenGnome : Interactable {

    public AudioSource myAudioSource;
    public AudioClip breakClip;

	public override void Die()
    {
        base.Die();
        myAudioSource.PlayOneShot(breakClip);
    }
}
