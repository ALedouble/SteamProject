using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour {

	[System.NonSerialized] public Rigidbody rb;
	[System.NonSerialized] public Collider col;
	float breakThrowForce = 1;

	// Use this for initialization
	void Awake () {
		Initialize();
	}

	void Disappear()
	{
		rb.isKinematic = true;
		col.enabled = false;
	}

	void Initialize()
	{
		rb = GetComponent<Rigidbody>();
		col = GetComponent<Collider>();
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

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Ground")
		{
			Disappear();
		}
	}
}
