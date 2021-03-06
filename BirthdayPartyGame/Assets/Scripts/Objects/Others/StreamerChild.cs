﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamerChild : MonoBehaviour {

	bool isPost;

	public Transform self;
	Rigidbody body;
	public Vector3 pos;
	public Vector3 offset;
	LineRenderer line;
	List<SpringJoint> joints = new List<SpringJoint>();

	int jointsNb = -1;
	[System.NonSerialized] public bool animated;

	private void Start()
	{
		body = GetComponent<Rigidbody>();
		self = transform;
		if (body.isKinematic) isPost = true;
		else
		{
			line = GetComponent<LineRenderer>();
			GetJoints();
			jointsNb = joints.Count;
		}

		pos = new Vector3(self.position.x, self.position.y + self.localScale.y/2, self.position.z);
	}

	void GetJoints()
	{
		joints.Clear();

		if (jointsNb == 0)
		{
			line.positionCount = 0;
			return;
		}

		SpringJoint[] newJoints = GetComponents<SpringJoint>();
		
		//print("Current joints: " + newJoints.Length);
		for (int i = 0; i < newJoints.Length; i++)
		{
			joints.Add(newJoints[i]);
		}
		line.positionCount = joints.Count * 2;
		if (joints.Count == 0)
		{
			line.enabled = false;
		}
	}

	private void Update()
	{
		pos = new Vector3(self.position.x, self.position.y + /*self.localScale.y/2*/offset.y, self.position.z);
		if (animated)
		{
			if (!body.isKinematic && !isPost)
			{
				body.isKinematic = true;
				for (int i = 0; i < line.positionCount; i++)
				{
					line.SetPosition(i, new Vector3(100, 100, 100));
				}
			}
			
		}
		else
		{
			if (body.isKinematic && !isPost)
			{
				body.isKinematic = false;
			}
			
			if (!isPost)
			{
				for (int i = 0; i < joints.Count; i++)
				{
					if (joints[i] != null)
					{
						line.SetPosition(2 * i, joints[i].connectedBody.GetComponent<StreamerChild>().pos);
						line.SetPosition(2 * i + 1, pos);
					}
				}
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Interactable")
		{
			Interactable other = collision.collider.GetComponent<Interactable>();
			if (other.parameters.name == "Lawnmower" && joints[0] != null)
			{
				Vector3 _direction = self.position - other.self.position;
				body.AddForce(_direction.normalized * (joints[0].breakForce *2), ForceMode.VelocityChange);
			}
		}
	}

	private void OnJointBreak(float breakForce)
	{
		jointsNb--;
		GetJoints();
	}

	//public override void Die()
	//{
	//	base.Die();

	//}

}
