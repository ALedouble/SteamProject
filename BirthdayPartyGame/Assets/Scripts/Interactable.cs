using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public ObjectProfile profile; 

	// Use this for initialization
	void Awake () {
		if (profile.pickUp) gameObject.AddComponent<PickUpObject>();
		if (profile.breakable) gameObject.AddComponent<Breakable>();
		if (profile.electronic)
		{
			Electronic electronicScript = gameObject.AddComponent<Electronic>();
			electronicScript.Initialize(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void Activate() {}

	public virtual void Deactivate() { }
}
