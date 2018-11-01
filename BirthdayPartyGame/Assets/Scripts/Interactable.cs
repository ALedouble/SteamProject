using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectParameters))]
public class Interactable : MonoBehaviour {
	
	public ObjectParameters parameters;

	[System.NonSerialized]
	public bool canBreak;
	protected bool canActivate = true;
	

	// Use this for initialization
	void Awake () {
		if (parameters == null) parameters = GetComponent<ObjectParameters>();

		if (parameters.pickUp) gameObject.AddComponent<PickUpObject>();
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
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void Activate() { }

	public virtual void Deactivate() { }

	public virtual void Die() { }
}
