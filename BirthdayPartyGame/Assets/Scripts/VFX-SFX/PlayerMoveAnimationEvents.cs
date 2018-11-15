using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnimationEvents : MonoBehaviour {

    public AudioSource myAudioSource;
    public AudioClip leftFootGrassClip;
    public AudioClip rightFootGrassClip;

    public void PlayLeftFootGrassClip()
    {
        myAudioSource.PlayOneShot(leftFootGrassClip);
    }

    public void PlayRightFootGrassClip()
    {
        myAudioSource.PlayOneShot(rightFootGrassClip);
    }
}
