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

    [HideInInspector]
    public bool uiOpened;
    public Animator cameraAnim;
    public Animator levelSelectionContainerAnim;

    void OnEnable () {

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
        print(levelsUI[0]);

		SetUpLevelUI();
	}

	void SetUpLevelUI()
	{
		currentLevel = SaveManager.instance.currentSave.levels[levelIndex];
		currentLevelUI.Initialize(currentLevel.name, currentLevel.description, currentLevel.objectiveNames, currentLevel.id, currentLevel.subObjectiveNames, currentLevel.completedSecondaryObjectives, currentLevel.timer, currentLevel.id);
	}
	
	void Update () {
		GetInput();
        UpdatePadMoves();
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
            levelSelectionContainerAnim.SetBool("OpenBool", false);
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
        if(uiOpened)
            SceneManager.LoadScene(levelIndex+1);
	}

    void UpdatePadMoves()
    {
        if (padMoveLeftTimer > 0)
        {
            padMoveLeftTimer -= Time.unscaledDeltaTime;
        }
        if (padMoveRightTimer > 0)
        {
            padMoveRightTimer -= Time.unscaledDeltaTime;
        }
    }

    public void LaunchingOpenAnim()
    {
        levelSelectionContainerAnim.SetBool("OpenBool", true);
    }

    /*IEnumerator ScaleUIComponents(Vector3 from, Vector3 to)
    {
        lerpValue = Mathf.Clamp01(lerpValue + Time.deltaTime / timeToScale);
        for (int i = 0; i < uiToScale.Length; i++)
        {
            if(to == new Vector3(1, 1, 1))
            {
                uiToScale[i].localScale = Vector3.Lerp(from, to * upScaleAnimCurve.Evaluate(lerpValue), lerpValue);
            }
            else
            {
                uiToScale[i].localScale = Vector3.Lerp(from * downScaleAnimCurve.Evaluate(lerpValue), to, lerpValue);
            }
        }
        yield return new WaitForSeconds(0);

        if (lerpValue == 1)
        {
            if(to == new Vector3(1, 1, 1))
            {
                uiOpened = true;
            }
            else
            {
                uiOpened = false;
                cameraAnim.SetBool("SelectBool", false);
            }
        }
        else
        {
            StartCoroutine(ScaleUIComponents(from, to));
        }
    }*/
}
