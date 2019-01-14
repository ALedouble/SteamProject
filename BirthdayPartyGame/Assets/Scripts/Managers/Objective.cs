using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveType
{
	None,
	Destroy,
	PositionChild,
    Isolate,
	Activate
}

[System.Serializable]
public class Objective {

	public ObjectiveType type;
	public Interactable[] relatedObjects;
    public GameObject[] relatedGameObjects;
	bool setup;
	public bool[] activatedObjects;

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
            case ObjectiveType.Isolate:
                CheckIsolation();
                break;
			case ObjectiveType.Activate:
				if (!setup)
				{
					setup = true;
					activatedObjects = new bool[relatedObjects.Length];
					for (int i = 0; i < relatedObjects.Length; i++)
					{
						relatedObjects[i].ActionEvent += CheckActivate;
					}
				}
				break;
		}
	}

	void CheckDestroyed()
	{
		for (int i = 0; i < relatedObjects.Length; i++)
		{
			if (relatedObjects[i] != null/* && relatedObjects[i].enabled*/)
			{
				return;
			}
		}
        Debug.Log ("About to win");
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

    void CheckIsolation()
    {
        //related game objects : 0 = SphereCollider / 1 = Bridge
        if(relatedGameObjects[0].GetComponent<LD4CollisionAI>().douglasIsolated && !relatedGameObjects[1].GetComponent<BridgeSwitcher>().opened)
        {
            Validate();
        }
    }

	void CheckActivate(Interactable script)
	{
		for (int i = 0; i < relatedObjects.Length; i++)
		{
			if (script == relatedObjects[i])
			{
				activatedObjects[i] = true;
			}

		}

		for (int i = 0; i < activatedObjects.Length; i++)
		{
			if (!activatedObjects[i])
			{
				return;
			}
			else
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
