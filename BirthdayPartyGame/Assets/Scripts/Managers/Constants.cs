using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour {

	public static Constants constants;

	public GameObject fireParticle;
	public GameObject waterParticle;
	public GameObject electricityParticle;

	public void Awake()
	{
		constants = this;
	}

}
