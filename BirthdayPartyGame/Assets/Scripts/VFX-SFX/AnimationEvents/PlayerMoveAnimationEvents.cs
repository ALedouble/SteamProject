using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnimationEvents : MonoBehaviour {

	public PlayerController player;

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

	public void ActivateObject()
	{
		player.grabbedObject.Activate();
	}

	public void DeactivateObject()
	{
		player.grabbedObject.Deactivate();
	}

    public void ActivateBatTrail()
    {
        player.grabbedObject.transform.GetChild(1).GetComponent<TrailRenderer>().enabled = true;
    }

    public void DeactivateBatTrail()
    {
        player.grabbedObject.transform.GetChild(1).GetComponent<TrailRenderer>().enabled = false;
    }
}
