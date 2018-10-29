using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electronic : MonoBehaviour {

	Interactable main;
	Transform self;
	float electricityDetectionRadius = 5;
	bool isPowered;

	// Use this for initialization
	void Start () {
		self = transform;
		StartCoroutine(CheckElectricity());
	}

	IEnumerator CheckElectricity()
	{
		Collider[] collidedObjects = Physics.OverlapSphere(self.position, electricityDetectionRadius);
		if (collidedObjects.Length > 0)
		{
			if (HasElectricalStimulus(collidedObjects))
			{
				if (!isPowered) GetPowered();
			}
			else if (isPowered)
			{
				LosePower();
			}
		}
		
		yield return new WaitForSeconds(.2f);
		StartCoroutine(CheckElectricity());
	}

	bool HasElectricalStimulus(Collider[] _collidedObjects)
	{
		for (int i = 0; i < _collidedObjects.Length; i++)
		{
			if (_collidedObjects[i].tag == "Interactable" && _collidedObjects[i].GetComponent<Interactable>().profile.electric)
			{
				return true;
			}
		}
		return false;
	}

	public void Initialize(Interactable creator)
	{
		main = creator;
	}

	void GetPowered()
	{
		isPowered = true;
		main.Activate();
	}

	void LosePower()
	{
		isPowered = false;
	}

}
