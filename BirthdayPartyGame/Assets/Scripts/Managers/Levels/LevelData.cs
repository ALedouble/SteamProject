using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour {

	public static LevelData instance;

	public byte id;
	public string levelName;
	public float levelTimer = 60;
	public string objectiveDescription = "Do something!";
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
