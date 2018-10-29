using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour {

	public Rigidbody rb;
	public Collider col;
	float breakThrowForce = 7;

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

	public void Break(Vector3 impactPoint)
	{
		transform.parent = null;
		rb.isKinematic = false;
		col.enabled = true;
		rb.AddForce((transform.position - impactPoint) * breakThrowForce, ForceMode.VelocityChange);
	}
}
