using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveType
{
	None,
	Destroy,
	PositionChild
}

[System.Serializable]
public class Objective {

	public ObjectiveType type;
	public Interactable[] relatedObjects;

	[Header("Position child parameters:")]
	public GameObject[] toPositionObjects;
	public bool strict;
	public ZoneBehaviour positionZone;
	List<GameObject> positionnedObjects;

	[HideInInspector] public bool validated;

	public void CheckValid()
	{
		switch (type)
		{
			case ObjectiveType.None:
				break;
			case ObjectiveType.Destroy:
				CheckDestroyed();
				break;
			case ObjectiveType.PositionChild:
				CheckPositionned();
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

	void CheckPositionned()
	{
		if (ZoneBehaviour.instance != null)
		{
			if (ZoneBehaviour.instance.collidingObjects.Count >= toPositionObjects.Length)
			{
				Validate();
			}
		}
	}

	void Validate()
	{
		validated = true;
		Debug.Log("Validate");
	}
}
