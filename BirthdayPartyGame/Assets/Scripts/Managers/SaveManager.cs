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
			public string[] subObjectiveNames;
			public string description;

			public bool complete;
			public bool[] completedSecondaryObjectives;

			public bool destructionComplete;
			public float highScore;

			public Level(byte _id, string _name, float _timer, string[] _objectiveNames, string[] _subObjectiveNames, string _description)
			{
				id = _id;
				name = _name;
				timer = _timer;
				objectiveNames = _objectiveNames;
				subObjectiveNames = _subObjectiveNames;
				description = _description;
				completedSecondaryObjectives = new bool[subObjectiveNames.Length];
				destructionComplete = false;
				highScore = 0;
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
	void Awake()
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

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Delete))
		{
			File.Delete(Application.persistentDataPath + "/Saves.bp");
		}
	}

	public void InitializeSave()
	{
		print("New save");
		BinaryFormatter _formatter = new BinaryFormatter();
		FileStream _file = File.Create(Application.persistentDataPath + "/Saves.bp");

		currentSave = new Save(new Save.Level[] {
			new Save.Level(0, "Level 1", 60, new string[] { "Destroy the cake!"}, new string[] { ""},
				"Learn to be bad"),
			new Save.Level(1, "Level 2", 60, new string[] { "Destroy the cake!"}, new string[] { "Drop the bass!"},
				"Throw it on the ground!"),
			new Save.Level(2, "Level 3", 60, new string[] { "Destroy the cake!"}, new string[] { "Break the pinata!", "Hang the DJ!" },
				"Bat out of hell"),
			new Save.Level(3, "Level 4", 60, new string[] { "Isolate Douglas on the island!"}, new string[] { ""},
				"Cast away"),
			new Save.Level(4, "Level 5", 60, new string[] { "Destroy the flowers!"}, new string[] { ""},
				"Flower power"),
			new Save.Level(5, "Level 6", 60, new string[] { "Burn the statue!"}, new string[] { ""},
				"No gods or kings"),
			new Save.Level(6, "Level 7", 60, new string[] { "Burn the presents!"}, new string[] { ""},
				"Some like it hot"),
			new Save.Level(7, "Level 8", 60, new string[] { "Burn the banners!"}, new string[] { "Ruin the cake!"},
				"The birthday boy with no name"),
			new Save.Level(8, "Level 9", 60, new string[] { "Burn the presents and pinata!"}, new string[] { ""},
				"Burn burn burn"),
			new Save.Level(9, "Level 10", 60, new string[] { "Burn the present!"}, new string[] { ""},
				"Kill it with fire!"),
			new Save.Level(9, "Level 11", 60, new string[] { "Make them cry!"}, new string[] { ""},
				"TNT"),
			new Save.Level(10, "Level 12", 60, new string[] { "Break the table!"}, new string[] { ""},
				"Break it down!"),
				new Save.Level(11, "Level 14", 60, new string[] { "Destroy the toybox!"}, new string[] { ""},
				"The cannoneer")
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
			currentSave.progressionIndex = id+1;
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

	public void SaveDestructionProgress(byte id, float _score)
	{
		currentSave.levels[id].destructionComplete = true;
		currentSave.levels[id].highScore = _score;
		SaveGame();
	}

}
