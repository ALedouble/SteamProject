using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour {

	static public LevelSelectionManager instance;

	public LevelUI[] levelsUI;
	LevelUI currentLevelUI;
	SaveManager.Save.Level currentLevel;
	int levelIndex;
	public int levelsNumber = 2;
	public float animationDuration = .5f;

	bool canClick = true;

	float padMoveLeftTimer;
	float padMoveRightTimer;

	// Use this for initialization
	void Start () {

		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		levelsNumber = SaveManager.instance.currentSave.levels.Length;
		levelIndex = SaveManager.instance.currentSave.progressionIndex;
		currentLevelUI = levelsUI[0];

		SetUpLevelUI();
	}

	void SetUpLevelUI()
	{
		currentLevel = SaveManager.instance.currentSave.levels[levelIndex];
		currentLevelUI.Initialize(currentLevel.name, currentLevel.description, currentLevel.objectiveNames, currentLevel.id, currentLevel.subObjectiveNames, currentLevel.completedSecondaryObjectives, currentLevel.timer, currentLevel.id);
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();

		if (padMoveLeftTimer > 0)
		{
			padMoveLeftTimer -= Time.unscaledDeltaTime;
		}
		if (padMoveRightTimer > 0)
		{
			padMoveRightTimer -= Time.unscaledDeltaTime;
		}
	}

	void GetInput()
	{
		if (!canClick) return;

		if (( Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetAxisRaw("Horizontal") < -0.2f && padMoveLeftTimer <= 0) ) && levelIndex > 0)
		{
			SwitchLevel(false);
			padMoveLeftTimer = Constants.constants.gamepadMoveTimer;
			padMoveRightTimer = 0;
		}
		else if (( Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetAxisRaw("Horizontal") > 0.2f && padMoveRightTimer <= 0) )
			&& levelIndex < levelsNumber - 1 &&
				(levelIndex < SaveManager.instance.currentSave.progressionIndex || GameManager.instance.state == DevState.Debug))
		{
			SwitchLevel(true);
			padMoveRightTimer = Constants.constants.gamepadMoveTimer;
			padMoveLeftTimer = 0;
		}
		if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.2f)
		{
			padMoveRightTimer = 0;
			padMoveLeftTimer = 0;
		}

		if (Input.GetKey(KeyCode.Return) || Input.GetButtonDown("Grab"))
		{
			GoToLevel();
		}
		else if (Input.GetKey(KeyCode.Escape) || Input.GetButtonDown("Back"))
		{
			SceneManager.LoadScene(0);
		}
	}

	void SwitchLevel(bool right)
	{
		canClick = false;
		//Change the levelIndex
		if (right)
		{
			currentLevelUI.CtoL();
			if (currentLevelUI == levelsUI[0])
			{
				levelsUI[1].RtoC();
			}
			else
			{
				levelsUI[0].RtoC();
			}

			levelIndex++;

		}
		else
		{
			print("Going left");

			currentLevelUI.CtoR();
			if (currentLevelUI == levelsUI[0])
			{
				levelsUI[1].LtoC();
			}
			else
			{
				levelsUI[0].LtoC();
			}

			levelIndex--;
		}
		//Change the level data target
		currentLevel = SaveManager.instance.currentSave.levels[levelIndex];
		
		//Change the levelUI target
		if (currentLevelUI == levelsUI[0])
		{
			currentLevelUI = levelsUI[1];
		}
		else
		{
			currentLevelUI = levelsUI[0];
		}
		SetUpLevelUI();
	}

	public void EndSwitchLevel()
	{
		canClick = true;
		print("Can naviguate. Index: " + levelIndex);
	}


	public void GoToLevel()
	{
		SceneManager.LoadScene(levelIndex+1);
	}
}
