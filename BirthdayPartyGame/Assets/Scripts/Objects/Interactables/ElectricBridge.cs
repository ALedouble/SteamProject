using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBridge : Interactable {

	//public Animator anim;

	bool moving;

	Vector3 upRotation = new Vector3(90, 0, 0);
	Vector3 downRotation = new Vector3(0, 0, 0);

	public override void Activate()
	{
		base.Activate();
		print("Check activate");
		//transform.rotation = Quaternion.Euler(90, 0, 0);
		if (moving) return;
		
		if (!activated)
		{
			StartCoroutine(Lower());
		}
	}

	public override void Deactivate()
	{
		print("Deactivate");
		base.Deactivate();
		StartCoroutine(Rise());
	}

	IEnumerator Rise()
	{
		print("Rise");
		moving = true;
		for (float i = 0; i < 1; i+=Time.deltaTime)
		{
			transform.rotation = Quaternion.Slerp(Quaternion.Euler(downRotation), Quaternion.Euler(upRotation), i);
			yield return null;
		}
		transform.rotation = Quaternion.Euler(upRotation);
		activated = false;
		moving = false;
		//anim.SetTrigger("Move");
		//anim.speed = 1;
	}

	IEnumerator Lower()
	{
		print("Lower");
		moving = true;
		for (float i = 0; i < 1; i += Time.deltaTime)
		{
			transform.rotation = Quaternion.Slerp(Quaternion.Euler(upRotation), Quaternion.Euler(downRotation), i);
			yield return null;
		}
		transform.rotation = Quaternion.Euler(downRotation);
		activated = true;
		moving = false;
		//anim.SetTrigger("Move");
		//anim.speed = -1;
	}

}
