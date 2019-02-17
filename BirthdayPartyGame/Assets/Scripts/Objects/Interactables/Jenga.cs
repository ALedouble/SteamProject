using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jenga : MonoBehaviour {

    public AudioSource myAudioSource;
    public AudioClip jengaHitClip;
    bool playedSoundAlready;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Jenga" && !playedSoundAlready)
        {
            playedSoundAlready = true;
            myAudioSource.PlayOneShot(jengaHitClip);
        }
    }
}
