﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPistol : Interactable {

	public GameObject waterDrop;
	public Transform spawnPoint;
	public float force = 16;
	public float shotsInterval = 0.5f;
    public AudioSource myAudioSource;
    public AudioClip waterPistolShootClip;
    public GameObject waterPart;

	public override void Activate()
	{
		base.Activate();
		StartCoroutine(ShootWater());
	}

	IEnumerator ShootWater()
	{
		GameObject gameObjectRef1 = Instantiate(waterDrop, spawnPoint.position, self.rotation);
        Vector3 forceToAdd = force * self.forward;
        forceToAdd.y = 1;
        gameObjectRef1.GetComponent<Rigidbody>().AddForce(forceToAdd);
        GameObject waterPartRef = Instantiate(waterPart, spawnPoint.position, self.rotation);
        Destroy(waterPartRef, 0.5f);
        myAudioSource.PlayOneShot(waterPistolShootClip);
		canActivate = false;
		yield return new WaitForSeconds(shotsInterval);
		canActivate = true;
	}
}
