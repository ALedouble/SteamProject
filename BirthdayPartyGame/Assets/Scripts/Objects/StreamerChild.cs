using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamerChild : MonoBehaviour {

	Transform self;
	Rigidbody body;
	public Vector3 pos;

	private void Start()
	{
		body = GetComponent<Rigidbody>();
		self = transform;
		pos = new Vector3(self.position.x, self.position.y + self.localScale.y/2, self.position.z);
	}


	private void Update()
	{
		pos = new Vector3(self.position.x, self.position.y + self.localScale.y / 2, self.position.z);
		//if (GetComponent<SpringJoint>().)
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!body.isKinematic && collision.collider.tag == "Interactable")
		{
			ObjectParameters other = collision.collider.GetComponent<ObjectParameters>();
			if (other.objectName == "Lawnmower")
			{
				print("I knew it!");
			}
		}
	}
}
