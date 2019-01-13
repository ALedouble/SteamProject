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
			new Save.Level(0, "Level 2", 60, new string[] { "Destroy the cake!"},
				"Destroy the Leo's cake to make him cry"),
			new Save.Level(1, "Level 3", 60, new string[] { "Destroy the cake!"},
				"This is the third level!"),
			new Save.Level(2, "Level 4", 60, new string[] { "Isolate Douglas on the island!"},
				"Doug is afraid of water since he's seen Cast Away. Let's be naughty!"),
			new Save.Level(3, "Level 6", 60, new string[] { "Do something!"},
				"This is the sixth level!"),
			new Save.Level(4, "Level 7", 60, new string[] { "Do something!"},
				"Let's get naughty, birthday boys!"),
			new Save.Level(5, "Level 8", 60, new string[] { "Burn the banners!"},
				"Tim loves his name. Let's throw off his groove today..."),
			new Save.Level(6, "Level 10", 60, new string[] { "Burn the thing!"},
				"Kill it with fire!"),
			new Save.Level(7, "Level 12", 60, new string[] { "Do something!"},
				"And for the grand finale!")
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
