using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFenceSound : MonoBehaviour {

    public static StaticFenceSound fenceAudio;
    public AudioSource myAudioSource;
    public AudioClip woodExplosionClip;

    // Use this for initialization
    void Start () {
        fenceAudio = this;
	}

    public void PlayWoodExplosion(Vector3 _newPosition)
    {
        transform.position = _newPosition;
        myAudioSource.Stop();
        myAudioSource.PlayOneShot(woodExplosionClip);
    }
}
