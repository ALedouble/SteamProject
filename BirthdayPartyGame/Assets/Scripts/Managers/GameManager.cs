using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DevState
{
	Test,
	Debug
}

public class GameManager : MonoBehaviour {

	static public GameManager instance;

	public DevState state = DevState.Debug;
	public AudioSource source;

	// Use this for initialization
	void Start () {
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F1))
		{
			if (state == DevState.Test)
			{
				state = DevState.Debug;
			}
			else
			{
				state = DevState.Test;
			}
		}

		if (source.isPlaying && SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 14)
		{
			source.Stop();
		}
		else if (!source.isPlaying && (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 14))
		{
			source.Play();
		}
	}
}
