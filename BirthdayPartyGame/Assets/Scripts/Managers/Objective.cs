using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveType
{
	None,
	Destroy,
	PickUp
}

[System.Serializable]
public class Objective {

	public ObjectiveType type;
	public Interactable[] relatedObjects;
	[System.NonSerialized] public bool validated;

	public void CheckValid()
	{
		switch (type)
		{
			case ObjectiveType.None:
				break;
			case ObjectiveType.Destroy:
				CheckDestroyed();
				break;
			case ObjectiveType.PickUp:
				CheckDestroyed();
				break;
		}
	}

	void CheckDestroyed()
	{
		for (int i = 0; i < relatedObjects.Length; i++)
		{
			if (relatedObjects[i] != null && relatedObjects[i].enabled)
			{
				return;
			}
		}
		Validate();
	}

	void Validate()
	{
		validated = true;
		Debug.Log("Validate");
	}

}
