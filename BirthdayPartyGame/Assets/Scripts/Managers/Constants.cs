using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour {

	public static Constants constants;

	public GameObject fireParticle;
	public GameObject waterParticle;
	public GameObject electricityParticle;

	[System.NonSerialized] public float fireDestructionAmount = 5;
	[System.NonSerialized] public float cryingDestructionAmount = 50;
	[System.NonSerialized] public float gamepadMoveTimer = 0.3f;

	public void Awake()
	{
		constants = this;
	}

}
