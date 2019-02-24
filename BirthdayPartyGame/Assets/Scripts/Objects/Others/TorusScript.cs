using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusScript : MonoBehaviour {

	public Interactable linkedObject;

	// Use this for initialization
	void Start () {
		if (linkedObject != null)
			linkedObject.DieEvent += Die;
	}
	
	// Update is called once per frame
	void Die(Interactable _script)
	{
		gameObject.SetActive(false);
	}
}
