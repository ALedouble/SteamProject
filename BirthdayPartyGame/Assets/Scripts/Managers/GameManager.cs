using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DevState
{
	Test,
	Debug
}

public enum LevelsMode
{
	Default,
	Destruction
}

public class GameManager : MonoBehaviour {

	static public GameManager instance;

	public DevState state = DevState.Debug;
	public LevelsMode mode = LevelsMode.Default;
	public AudioSource source;

	public delegate void ModeChange(LevelsMode newMode);
	public ModeChange ModeChangeEvent;

	public bool startMenuOnLevelSelection;
	//float padMoveUpTimer;

	// Use this for initialization
	void Start () {
		print("Game manager START");
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
		//if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.2f && padMoveUpTimer <= 0))
		//{
		//	ToggleDestructionMode();
		//	padMoveUpTimer = Constants.constants.gamepadMoveTimer;
		//}
		//if (padMoveUpTimer > 0)
		//{
		//	padMoveUpTimer -= Time.unscaledDeltaTime;
		//}

		if (source.isPlaying && SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 14)
		{
			source.Stop();
		}
		else if (!source.isPlaying && (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 14))
		{
			source.Play();
		}
	}

	public void ToggleDestructionMode()
	{
		if (mode == LevelsMode.Default)
		{
			mode = LevelsMode.Destruction;
		}
		else
		{
			mode = LevelsMode.Default;
		}
		if (ModeChangeEvent != null)
		{
			ModeChangeEvent(mode);
		}
	}
}
