using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPistol : Interactable {

	public GameObject waterDrop;

	public override void Activate()
	{
		base.Activate();
		StartCoroutine(ShootWater());
	}

	IEnumerator ShootWater()
	{
		GameObject gameObjectRef1 = Instantiate(waterDrop, self.position, self.rotation);
		gameObjectRef1.GetComponent<Rigidbody>().AddForce(400 * self.forward + 100 * Vector3.up);
		canActivate = false;
		yield return new WaitForSeconds(0.1f);
		canActivate = true;
	}
}
