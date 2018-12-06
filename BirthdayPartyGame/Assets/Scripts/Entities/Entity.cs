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
		print("Start spread check");
		//if (!this.enabled)
		//{
		//	StopAllCoroutines();
		//	yield return null;
		//}
		print("Verify can spread");
		if (canSpread)
		{
			print("Initialize");
			canSpreadObjects.Clear();
			Vector3 pos;
			print("About to get node/position");
			if (main.parameters.node != null)
			{
				pos = main.parameters.node.position;
			}
			else
			{
				pos = transform.position;
			}
			print("About to get Colliders");
			Collider[] colliders = Physics.OverlapSphere(pos, radius);
			print("About to Check Objects");
			if (colliders.Length > 0) CheckObjects(colliders);
			print("About to Spread Objects");
			if (canSpreadObjects.Count > 0) Spread();
			print("Spread completed");
		}
		print("About to restart");
		//yield return new WaitForSeconds(.2f);
		//StartCoroutine(CheckSpread());
	}

	protected virtual void CheckObjects(Collider[] _colliders)
	{
		for (int i = 0; i < _colliders.Length; i++)
		{
			if (_colliders[i].tag == "Interactable")
			{
				Interact(_colliders[i].GetComponent<Interactable>());
			}
		}
	}

	protected virtual void Interact(Interactable _object) { }

	protected virtual void Spread() { }

}
