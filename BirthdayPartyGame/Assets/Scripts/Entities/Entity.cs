using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : InteractableComponent {

	Transform self;

	protected float radius = 3;
	protected float maturingTime = 1;
	float lifeSpan;
	public bool canSpread;
	protected List<Interactable> canSpreadObjects = new List<Interactable>();

	void Start()
	{
		Initialize();
	}

	private void OnEnable()
	{
		Initialize();
	}

	void Initialize()
	{
		main = GetComponent<Interactable>();
		self = transform;
		//StartCoroutine(CheckSpread());
	}
	// Update is called once per frame
	void Update()
	{
		if (!canSpread)
		{
			if (lifeSpan < maturingTime)
				lifeSpan += Time.deltaTime;
			else
				canSpread = true;
		}
	}

	private void FixedUpdate()
	{
		CheckSpread();
	}

	void CheckSpread()
	{
		if (!this.enabled) return;
		if (canSpread)
		{
			canSpreadObjects.Clear();
			//Vector3 pos;
			//if (main.parameters.nodes.Length > 0)
			//{
			//	pos = main.parameters.nodes.position;
			//}
			//else
			//{
			//	pos = self.position;
			//}
			Collider[] colliders = Physics.OverlapSphere(self.position, radius);
			if (colliders.Length > 0) CheckObjects(colliders);
			if (canSpreadObjects.Count > 0) Spread();
		}
	}

	protected virtual void CheckObjects(Collider[] _colliders)
	{
		for (int i = 0; i < _colliders.Length; i++)
		{
			if (_colliders[i].GetComponent<Interactable>() != null)
			{
				Interact(_colliders[i].GetComponent<Interactable>());
			}
		}
	}

	protected virtual void Interact(Interactable _object) { }

	protected virtual void Spread() { }

}
