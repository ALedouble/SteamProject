using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : InteractableComponent {
	
	BodyPart[] parts;
	public float breakSpeed;
	public Rigidbody rb;
	Transform self;
	bool broken;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		self = GetComponent<Transform>();
		if (main.parameters.destructible) GetParts();
		else parts = new BodyPart[0];
	}

	void GetParts()
	{		
		Transform bodyPartsChild = self.GetChild(0);
		parts = new BodyPart[bodyPartsChild.childCount];
		for (int i = 0; i < bodyPartsChild.childCount; i++)
		{
			parts[i] = bodyPartsChild.GetChild(i).GetComponent<BodyPart>();
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
		if (broken) return;

		if (parts.Length > 0)
		{
			for (int i = 0; i < parts.Length; i++)
			{
				parts[i].Break(impactPoint);
			}
		}

		if (GameManager.instance != null &&  GameManager.instance.mode == LevelsMode.Destruction)
			DestructionManager.instance.AddDestruction(transform.position, /*main.parameters.destructionScore*/ 50);

		main.Die();

		broken = true;
	}
}
