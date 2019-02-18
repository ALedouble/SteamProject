using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveType
{
	None,
	Destroy,
	PositionChild,
    Isolate,
	Activate,
	Grab, 
	Cry
}

[System.Serializable]
public class Objective {

    [HideInInspector]
    public AudioClip validatingClip;
	public ObjectiveType type;
	public Interactable[] relatedObjects;
	public AIV2[] relatedChildren;
	public GameObject[] relatedGameObjects;
	//bool setup;
	public bool[] checkedObjects;
	BridgeSwitcher bridge;
	LD4CollisionAI doug;

	//[Header("Position child parameters:")]
	//public GameObject[] toPositionObjects;
	//public bool strict;
	//public ZoneBehaviour positionZone;
	//List<GameObject> positionnedObjects;

	/*[HideInInspector]*/ public bool validated;

	public delegate void Win();
	public Win WinEvent;

	public void InitializeObjective()
	{
		switch (type)
		{
			case ObjectiveType.Destroy:
				checkedObjects = new bool[relatedObjects.Length];
				for (int i = 0; i < relatedObjects.Length; i++)
				{
					relatedObjects[i].DieEvent += CheckObject;
				}
				break;
			case ObjectiveType.Isolate:
				for (int i = 0; i < relatedGameObjects.Length; i++)
				{
					if (relatedGameObjects[i].GetComponent<LD4CollisionAI>() != null)
					{
						doug = relatedGameObjects[i].GetComponent<LD4CollisionAI>();
					}
					else if (relatedGameObjects[i].GetComponent<BridgeSwitcher>() != null)
					{
						bridge = relatedGameObjects[i].GetComponent<BridgeSwitcher>();
						bridge.DeactivateEvent += CheckIsolation;
					}
				}
				break;
			case ObjectiveType.Activate:
				checkedObjects = new bool[relatedObjects.Length];
				for (int i = 0; i < relatedObjects.Length; i++)
				{
					relatedObjects[i].ActionEvent += CheckObject;
				}
				break;
			case ObjectiveType.Grab:
				checkedObjects = new bool[relatedObjects.Length];
				for (int i = 0; i < relatedObjects.Length; i++)
				{
					relatedObjects[i].GrabEvent += CheckObject;
				}
				break;

			case ObjectiveType.Cry:
				checkedObjects = new bool[relatedChildren.Length];
				for (int i = 0; i < relatedChildren.Length; i++)
				{
					relatedChildren[i].Cry += CheckCry;
					relatedChildren[i].Cry += CheckStopCrying;
				}
				break;
		}
	}

	//public void CheckValid()
	//{
	//	switch (type)
	//	{
	//		case ObjectiveType.None:
	//			break;
	//		case ObjectiveType.Destroy:
	//			CheckDestroyed();
	//			break;
	//		case ObjectiveType.PositionChild:
	//			CheckPositionned();
	//			break;
 //           case ObjectiveType.Isolate:
 //               CheckIsolation();
 //               break;
	//		case ObjectiveType.Activate:
	//			if (!setup)
	//			{
	//				setup = true;
	//				checkedObjects = new bool[relatedObjects.Length];
	//				for (int i = 0; i < relatedObjects.Length; i++)
	//				{
	//					relatedObjects[i].ActionEvent += CheckObject;
	//				}
	//			}
	//			break;
	//		case ObjectiveType.Grab:
	//			if (!setup)
	//			{
	//				setup = true;
	//				checkedObjects = new bool[relatedObjects.Length];
	//				for (int i = 0; i < relatedObjects.Length; i++)
	//				{
	//					relatedObjects[i].GrabEvent += CheckObject;
	//				}
	//			}
	//			break;
	//	}
	//}

	//void CheckDestroyed()
	//{
	//	for (int i = 0; i < relatedObjects.Length; i++)
	//	{
	//		if (relatedObjects[i] != null/* && relatedObjects[i].enabled*/)
	//		{
	//			return;
	//		}
	//	}
 //       Debug.Log ("About to win");
	//	Validate();
	//}

	void CheckPositionned()
	{
		//if (ZoneBehaviour.instance != null)
		//{
		//	if (ZoneBehaviour.instance.collidingObjects.Count >= toPositionObjects.Length)
		//	{
		//		Validate();
		//	}
		//}
	}

    void CheckIsolation(Interactable script)
    {
        //related game objects : 0 = SphereCollider / 1 = Bridge
        if(doug.douglasIsolated && !bridge.opened)
        {
            Validate();
        }
    }

	void CheckObject(Interactable script)
	{
		for (int i = 0; i < relatedObjects.Length; i++)
		{
			if (script == relatedObjects[i])
			{
				checkedObjects[i] = true;
			}

		}

		for (int i = 0; i < checkedObjects.Length; i++)
		{
			if (!checkedObjects[i])
			{
				return;
			}
			else
			{
				Validate();
			}
		}
	}

	public void CheckCry(AIV2 child)
	{
		for (int i = 0; i < relatedChildren.Length; i++)
		{
			if (child == relatedChildren[i])
			{
				checkedObjects[i] = true;
			}

		}

		for (int i = 0; i < checkedObjects.Length; i++)
		{
			if (!checkedObjects[i])
			{
				return;
			}
			else
			{
				Validate();
			}
		}
	}

	public void CheckStopCrying(AIV2 child)
	{
		for (int i = 0; i < relatedChildren.Length; i++)
		{
			if (child == relatedChildren[i])
			{
				checkedObjects[i] = false;
			}

		}
	}

	void Validate()
	{
        GameObject.Find("LevelAudioSource").GetComponent<AudioSource>().PlayOneShot(validatingClip);
		validated = true;
		Debug.Log("Validate");
		if (WinEvent != null)
			WinEvent();
	}
}
