using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour {

	public Rigidbody rb;
	public Collider col;

	// Use this for initialization
	void Awake () {
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Initialize()
	{
		rb.isKinematic = true;
		col.enabled = false;
	}
}
