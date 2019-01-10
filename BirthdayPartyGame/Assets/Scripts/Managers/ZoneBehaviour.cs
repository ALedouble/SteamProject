using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBehaviour : MonoBehaviour {

	public static ZoneBehaviour instance;

	Collider col;
	public List<GameObject> collidingObjects = new List<GameObject>();

	private void Awake()
	{
		col = GetComponent<Collider>();

		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		
		for (int i = 0; i < LevelData.instance.mainObjectives.Length; i++)
		{
			if (LevelData.instance.mainObjectives[i].type == ObjectiveType.PositionChild)
			{
				return;
			}
		}

		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		for (int i = 0; i < LevelData.instance.mainObjectives.Length; i++)
		{
			if (LevelData.instance.mainObjectives[i].type == ObjectiveType.PositionChild)
			{
				for (int x = 0; x < LevelData.instance.mainObjectives[i].toPositionObjects.Length; x++)
				{
					if (LevelData.instance.mainObjectives[i].toPositionObjects[x] = other.gameObject)
					{
						collidingObjects.Add(other.gameObject);
					}
				}
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		for (int i = 0; i < collidingObjects.Count; i++)
		{
			if (other.gameObject == collidingObjects[i])
			{
				collidingObjects.Remove(other.gameObject);
			}
		}
	}
}
