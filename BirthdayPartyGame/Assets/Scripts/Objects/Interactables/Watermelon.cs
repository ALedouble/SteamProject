using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : Interactable {

    public AudioClip sproutchClip;

    public override void Die()
    {
        GameObject.Find("LevelAudioSource").GetComponent<AudioSource>().PlayOneShot(sproutchClip);
        base.Die();
    }
}
