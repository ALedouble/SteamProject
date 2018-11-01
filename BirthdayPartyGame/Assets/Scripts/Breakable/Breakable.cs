using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

	Interactable main;

	BodyPart[] parts;
	public float breakSpeed;
	public Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		if (main.parameters.destructible) GetParts();
		else parts = new BodyPart[0];
	}

	public void Initialize(Interactable creator)
	{
		main = creator;
	}

	void GetParts()
	{
		parts = new BodyPart[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
		{
			parts[i] = transform.GetChild(i).GetComponent<BodyPart>();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Interactable")
		{
			Interactable _object = collision.gameObject.GetComponent<Interactable>();
			if (_object.parameters.blunt && _object.canBreak)
			{
				Break(collision.contacts[0].point);
			}
		}
	}

	public void Break(Vector3 impactPoint)
	{
		if (parts.Length > 0)
		{
			for (int i = 0; i < parts.Length; i++)
			{
				parts[i].Break(impactPoint);
			}
			gameObject.SetActive(false);
		}
		main.Die();
	}
}
