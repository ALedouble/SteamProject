using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

	BodyPart[] parts;
	public float breakSpeed;
	public Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		GetParts();
	}

	void GetParts()
	{
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
			if (_object.profile.blunt && collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > breakSpeed)
			{
				Break(collision.contacts[0].point);
			}
		}
	}

	public void Break(Vector3 impactPoint)
	{

		for (int i = 0; i < parts.Length; i++)
		{
			parts[i].Break(impactPoint);
		}
		gameObject.SetActive(false);

		print("Break");
	}
}
