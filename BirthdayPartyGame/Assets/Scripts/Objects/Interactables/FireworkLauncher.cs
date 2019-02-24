using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkLauncher : Interactable {

	/* public float cooldownMaxValue;
	 float cooldown;
	 public GameObject[] fireworks;
	 int whichFirework;

	 protected override void Start()
	 {
		 cooldown = cooldownMaxValue;
	 }

	 private void Update()
	 {
		 if (burning && whichFirework<fireworks.Length-1)
		 {
			 if (cooldown > 0)
			 {
				 cooldown -= Time.deltaTime;
			 }
			 else
			 {
				 LaunchFirework();
				 cooldown = cooldownMaxValue;
				 whichFirework++;
			 }
		 }
	 }

	 void LaunchFirework()
	 {
		 fireworks[whichFirework].SetActive(false);
	 }*/
	public GameObject fireworkPrefab;
	public Transform spawnPoint;
	public float force;
	public int maxObject;
	public Vector3 directionOffset;
	public Animator myAnim;
	public AudioSource myAudioSource;
	//public AudioClip launchingClip;
	//public AudioClip preparingClip;

	public override void Burn()
	{
		base.Burn();
		Activate();
	}

	public override void StopBurning()
	{
		base.StopBurning();
		Deactivate();
	}

	public override void Activate()
	{
		base.Activate();
		//myAnim.SetBool("ActivatedBool", true);
		//LaunchBall();
	}
	public override void Deactivate()
	{
		base.Deactivate();
		//myAnim.SetBool("ActivatedBool", false);
	}

	public void Launch()
	{
		ILaunchable newBall = Instantiate(fireworkPrefab, spawnPoint.position, Quaternion.Euler(90, 90, 0)).GetComponent<ILaunchable>();
		newBall.GetLaunched(self.forward + directionOffset, force);
		newBall.ShootToBreak();
		//myAudioSource.PlayOneShot(launchingClip);
	}

	public void PlayPreparingClip()
	{
		//myAudioSource.PlayOneShot(preparingClip);
	}
}
