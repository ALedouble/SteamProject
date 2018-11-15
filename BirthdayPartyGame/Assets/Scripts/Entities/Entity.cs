﻿using System.Collections;
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
		StartCoroutine(CheckSpread());
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

	IEnumerator CheckSpread()
	{
		if (!this.enabled)
		{
			StopAllCoroutines();
			yield return null;
		}

		if (canSpread)
		{
			canSpreadObjects.Clear();
			Collider[] colliders = Physics.OverlapSphere(self.position, radius);
			if (colliders.Length > 0) CheckObjects(colliders);
			if (canSpreadObjects.Count > 0) Spread();
		}

		yield return new WaitForSeconds(.2f);
		StartCoroutine(CheckSpread());
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
