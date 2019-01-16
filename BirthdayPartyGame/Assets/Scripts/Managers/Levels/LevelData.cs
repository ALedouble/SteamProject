﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{

	public static LevelData instance;

	public byte id;
	public string levelName;
	public float levelTimer = 60;
	public string objectiveDescription = "Do something!";
	public Objective[] mainObjectives;
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
		for (int i = 0; i < mainObjectives.Length; i++)
		{
			mainObjectives[i].InitializeObjective();
		}
		for (int i = 0; i < secondaryObjectives.Length; i++)
		{
			secondaryObjectives[i].InitializeObjective();
		}
		SceneManager.LoadScene("LevelNecessities", LoadSceneMode.Additive);
	}

	public void Initialize(string _name, float _timer)
	{
		levelName = _name;
		levelTimer = _timer;
	}

}
