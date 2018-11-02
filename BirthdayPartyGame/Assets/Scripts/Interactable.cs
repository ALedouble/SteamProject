using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectParameters))]
public class Interactable : MonoBehaviour {
	
	public ObjectParameters parameters;

	public Rigidbody body;
	public Transform self;

	[System.NonSerialized]
	public bool canBreak;
	protected bool canActivate = true;
	

	// Use this for initialization
	void Awake () {
		if (parameters == null) parameters = GetComponent<ObjectParameters>();
		if (body == null) body = GetComponent<Rigidbody>();
		if (self == null) self = transform;

		if (parameters.breakable)
		{
			Breakable breakableScript = gameObject.AddComponent<Breakable>();
			breakableScript.Initialize(this);
		}
		if (parameters.electronic)
		{
			Electronic electronicScript = gameObject.AddComponent<Electronic>();
			electronicScript.Initialize(this);
		}
	}

	public void GetGrabbed(Transform _holdPoint)
	{
		self.position = _holdPoint.position;
		self.rotation = _holdPoint.rotation;
		self.parent = _holdPoint;
		body.isKinematic = true;
	}

	public void GetDropped()
	{
		self.parent = null;
		body.isKinematic = false;
	}

	public virtual void Activate() { }

	public virtual void Deactivate() { }

	public virtual void Die() { }
}
