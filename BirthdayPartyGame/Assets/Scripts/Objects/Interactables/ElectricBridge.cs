using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElectricBridge : Interactable {

	public Animator myAnim;
    public NavMeshObstacle myNavObstacle;
    public BoxCollider myCollider;
    public AudioSource myAudioSource;
    public AudioClip risingClip;
    public AudioClip loweringClip;

	public override void Activate()
	{
		base.Activate();		
		if (!activated)
		{
            myAnim.SetBool("UpBool", false);
            myNavObstacle.enabled = false;
            myCollider.enabled = false;
            activated = true;
            myAudioSource.PlayOneShot(loweringClip);
        }
	}

	public override void Deactivate()
	{
		base.Deactivate();
        myAnim.SetBool("UpBool", true);
        myNavObstacle.enabled = true;
        myCollider.enabled = true;
        activated = false;
        myAudioSource.PlayOneShot(risingClip);
    }

}
