using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	Transform self;
	
	float radius = 3;
	float maturingTime = 2;
	float lifeSpan;
	public bool canBurn;
	List<Interactable> canBurnObjects = new List<Interactable>();


	// Use this for initialization
	void Start ()
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
	void Update ()
	{
		if (!canBurn)
		{
			if (lifeSpan < maturingTime)
				lifeSpan += Time.deltaTime;
			else
				canBurn = true;
		}
	}

	IEnumerator CheckSpread()
	{
		if (!this.enabled)
		{
			StopAllCoroutines();
			yield return null;
		}
		
		if (canBurn)
		{
			canBurnObjects.Clear();
			Collider[] colliders = Physics.OverlapSphere(self.position, radius);
			if (colliders.Length > 0) CheckObjects(colliders);
			if (canBurnObjects.Count > 0) SpreadFire();
		}
		
		yield return new WaitForSeconds(.2f);
		StartCoroutine(CheckSpread());
	}

	void CheckObjects(Collider[] _colliders)
	{
		for (int i = 0; i < _colliders.Length; i++)
		{
			if (_colliders[i].tag == "Interactable" && _colliders[i] != GetComponent<Collider>())
			{
				Interactable _object = _colliders[i].GetComponent<Interactable>();
				if ((_object.parameters.material == ObjectMaterial.Wood || _object.parameters.material == ObjectMaterial.Paper) && 
					(!_object.wet && !_object.burning))
				{
					canBurnObjects.Add(_object);
				}
			}
		}
	}

	void SpreadFire()
	{
		for (int i = 0; i < canBurnObjects.Count; i++)
		{
			canBurnObjects[i].Burn(gameObject);
		}
	}
}
