using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

	BodyPart[] parts;
	public float breakSpeed;
	public Rigidbody rb;


	// Use this for initialization
	void Start () {
		parts = new BodyPart[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
		{
			parts[i] = transform.GetChild(i).GetComponent<BodyPart>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Interactable")
		{
			Interactable _object = collision.gameObject.GetComponent<Interactable>();
			if (_object.profile.isBlunt && collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > breakSpeed)
			{
				Break();
			}
		}
	}

	public void Break()
	{

		for (int i = 0; i < parts.Length; i++)
		{
			parts[i].transform.parent = null;
			parts[i].rb.isKinematic = false;
			parts[i].col.enabled = true;
		}
		gameObject.SetActive(false);

		print("Break");
	}
}
