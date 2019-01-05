using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveManager : MonoBehaviour {

	public class Save
	{
		public class Level
		{
			public byte id;
			public string name;
			public bool complete;
			public bool[] completedSecondaryObjectives;

			public Level(byte _id, string _name, bool _complete)
			{
				id = _id;
				name = _name;
				complete = _complete;
			}
		}

		public Level[] levels;
	}

	public static SaveManager instance;

	public Save currentSave;

	// Use this for initialization
	void Start () {
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(this);
		}
	}
	
	public void InitializeSave()
	{
		BinaryFormatter _formatter = new BinaryFormatter();
		FileStream _file = File.Create(Application.persistentDataPath + "/Saves.bp");
		_file.Close();
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
			currentSave.levels[id].complete = true;
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
