using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum CameraPosition
{
	Default,
	Near,
	Far
}

public class LevelData : MonoBehaviour
{

	public static LevelData instance;
    public AudioClip primaryObjectiveValidatingClip;
    public AudioClip secondaryObjectiveValidatingClip;
    public byte id;
	public string levelName;
	public float levelTimer = 60;
	public CameraPosition cameraPosition;
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
            mainObjectives[i].validatingClip = primaryObjectiveValidatingClip;
		}
		for (int i = 0; i < secondaryObjectives.Length; i++)
		{
			secondaryObjectives[i].InitializeObjective();
            secondaryObjectives[i].validatingClip = secondaryObjectiveValidatingClip;
        }
		SceneManager.LoadScene("LevelNecessities", LoadSceneMode.Additive);
		SaveManager.instance.currentSave.lastLevelIndex = id + 1;
	}

}
