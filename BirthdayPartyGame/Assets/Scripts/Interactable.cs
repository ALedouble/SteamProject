using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	[System.Serializable]
	public class ObjectParameters
	{
		public bool blunt;
		public bool breakable;
		public bool pickUp;
		public bool electronic;
		public bool electric;
		public ActivationType activationType;
	}

	public ObjectParameters parameters;
	[System.NonSerialized]
	public bool canBreak;

	//public ObjectProfile profile; 

	// Use this for initialization
	void Awake () {
		if (parameters.pickUp) gameObject.AddComponent<PickUpObject>();
		if (parameters.breakable) gameObject.AddComponent<Breakable>();
		if (parameters.electronic)
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
