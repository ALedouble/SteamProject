using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	Transform self;

	float radius = 3;
	float maturingTime = 1;
	float lifeSpan;
	public bool canWet;
	List<Interactable> canWetObjects = new List<Interactable>();

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
		self = transform;
		StartCoroutine(CheckSpread());
	}
	// Update is called once per frame
	void Update()
	{
		if (!canWet)
		{
			if (lifeSpan < maturingTime)
				lifeSpan += Time.deltaTime;
			else
				canWet = true;
		}
	}

	IEnumerator CheckSpread()
	{
		if (!this.enabled)
		{
			StopAllCoroutines();
			yield return null;
		}

		if (canWet)
		{
			canWetObjects.Clear();
			Collider[] colliders = Physics.OverlapSphere(self.position, radius);
			if (colliders.Length > 0) CheckObjects(colliders);
			if (canWetObjects.Count > 0) SpreadWater();
		}

		yield return new WaitForSeconds(.2f);
		StartCoroutine(CheckSpread());
	}

	void CheckObjects(Collider[] _colliders)
	{
		for (int i = 0; i < _colliders.Length; i++)
		{
			if (_colliders[i].tag == "Interactable")
			{
				Interactable _object = _colliders[i].GetComponent<Interactable>();
				if (_object.parameters.material == ObjectMaterial.Paper)
				{
					canWetObjects.Add(_object);
				}
				else if (_object.parameters.material == ObjectMaterial.Wood && _object.burning)
				{
					_object.StopBurning();
				}
			}
		}
	}

	void SpreadWater()
	{
		for (int i = 0; i < canWetObjects.Count; i++)
		{
			canWetObjects[i].GetWet();
		}
	}
}
