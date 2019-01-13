using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveManager : MonoBehaviour
{

	[System.Serializable]
	public class Save
	{
		[System.Serializable]
		public class Level
		{
			public byte id;
			public string name;
			public float timer;
			public string[] objectiveNames;
			public string description;

			public bool complete;
			public bool[] completedSecondaryObjectives;

			public Level(byte _id, string _name, float _timer, string[] _objectiveNames, string _description)
			{
				id = _id;
				name = _name;
				timer = _timer;
				objectiveNames = _objectiveNames;
				description = _description;
				completedSecondaryObjectives = new bool[objectiveNames.Length];
			}
		}

		public Level[] levels;
		public int progressionIndex = 0;

		public Save(Level[] _levels)
		{
			levels = _levels;
		}

	}

	public static SaveManager instance;

	public Save currentSave;

	// Use this for initialization
	void Start()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(this);
		}
		if (!File.Exists(Application.persistentDataPath + "/Saves.bp"))
		{
			InitializeSave();
		}
		else
		{
			LoadGame();
		}
	}

	public void InitializeSave()
	{
		BinaryFormatter _formatter = new BinaryFormatter();
		FileStream _file = File.Create(Application.persistentDataPath + "/Saves.bp");

		currentSave = new Save(new Save.Level[] {
			new Save.Level(0, "First level", 60, new string[] { "Burn the banners!"},
				"Destroy the banners with Tim's name to make him regret the day he dared get out of his mother's wretched womb."),
			new Save.Level(1, "Second level", 90, new string[] { "Do something, dude!"},
				"Do something, that outta do it, man!")
		});

		_formatter.Serialize(_file, currentSave);

		_file.Close();
		print(Application.persistentDataPath + "/Saves.bp");
	}

	public void LoadGame()
	{
		BinaryFormatter _formatter = new BinaryFormatter();
		FileStream _file = File.Open(Application.persistentDataPath + "/Saves.bp", FileMode.Open);
		currentSave = (Save)_formatter.Deserialize(_file);
		_file.Close();
	}

	public void SaveGame()
	{
		BinaryFormatter _formatter = new BinaryFormatter();
		FileStream _file = File.Open(Application.persistentDataPath + "/Saves.bp", FileMode.Open);
		_formatter.Serialize(_file, currentSave);
		_file.Close();
	}

	public void SaveProgress(byte id, bool completed, Objective[] secondaryObjective)
	{
		if (completed)
		{
			currentSave.levels[id].complete = true;
			currentSave.progressionIndex = id;
		}
		if (secondaryObjective.Length > 0)
		{
			//Complete sub objectives
			for (int i = 0; i < secondaryObjective.Length; i++)
			{
				if (secondaryObjective[i].validated)
				{
					currentSave.levels[id].completedSecondaryObjectives[i] = true;
				}
			}
		}
		SaveGame();
	}

}
