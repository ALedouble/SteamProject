﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : Interactable {

	public GameObject ballPrefab;
	public Transform spawnPoint;
	public float force;
    public int maxObject;
	public Vector3 directionOffset;
    public Animator myAnim;
    public AudioSource myAudioSource;
    public AudioClip launchingClip;
    public AudioClip preparingClip;
    int nbBallToThrow = 10;

	public override void Activate()
	{
		base.Activate();
        myAnim.SetBool("ActivatedBool", true);
		//LaunchBall();
	}
    public override void Deactivate()
    {
        base.Deactivate();
        myAnim.SetBool("ActivatedBool", false);
    }

    public void LaunchBall()
	{
        if (nbBallToThrow > 0)
        {
            nbBallToThrow--;
            ILaunchable newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity).GetComponent<ILaunchable>();
            newBall.GetLaunched(self.forward + directionOffset, force);
            newBall.ShootToBreak();
            myAudioSource.PlayOneShot(launchingClip);
        }
	}

    public void PlayPreparingClip()
    {
        myAudioSource.PlayOneShot(preparingClip);
    }
}
