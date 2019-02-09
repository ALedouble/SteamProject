using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : Interactable {

	public GameObject ballPrefab;
	public Transform spawnPoint;
	public float force;
	public Vector3 directionOffset;

	public override void Activate()
	{
		base.Activate();
		LaunchBall();
	}

	void LaunchBall()
	{
		ILaunchable newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity).GetComponent<ILaunchable>();

		newBall.GetLaunched(self.forward + directionOffset, force);
	}
}
