using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenLight : Interactable {

    public AudioSource myAudioSource;
    public AudioClip breakingClip;
    public GameObject flashPart;

    public override void Die()
    {
        if (!electrified)
        {
            GetElectrified(null);
            electricityScript.canSpread = true;
            electricityScript.firstGeneration = true;
            myAudioSource.PlayOneShot(breakingClip);
            GameObject flashPartRef = Instantiate(flashPart, transform.position + Vector3.up * 0.8f, Quaternion.identity);
            Destroy(flashPartRef, .5f);
        }
        //base.Die();
    }

}
