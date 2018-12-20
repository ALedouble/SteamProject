using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour {

	public static LevelData instance;

	public string levelName;
	public Objective mainObjective;
	public Objective[] secondaryObjectives;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

}
