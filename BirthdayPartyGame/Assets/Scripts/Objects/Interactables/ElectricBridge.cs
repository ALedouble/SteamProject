using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElectricBridge : Interactable {

	public Animator myAnim;
    public NavMeshObstacle myNavObstacle;
    public BoxCollider myCollider;

	public override void Activate()
	{
        print("herehere");
		base.Activate();		
		if (!activated)
		{
            print("here");
            myAnim.SetBool("UpBool", false);
            myNavObstacle.enabled = false;
            myCollider.enabled = false;
            activated = true;
        }
	}

	public override void Deactivate()
	{
		base.Deactivate();
        myAnim.SetBool("UpBool", true);
        myNavObstacle.enabled = true;
        myCollider.enabled = true;
        activated = false;
    }

}
