using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

	float levelTimer = 60;
	public Text firstTimerText;
	public Text secondTimerText;
	public Text thirdTimerText;
	public Text fourthTimerText;
	Text objectiveText;
	public GameObject uiObjective;
	public GameObject uiScore;
	public GameObject uiWin;
	public GameObject uiLose;
	public GameObject uiDestructionEnd;
	public Animator objectiveAnimator;
	protected bool gameEnd;
	int index = 0;
	bool hasReminded;
	bool lastSeconds;
	public float timerAcceleration = 1.5f;


	private void Start()
	{
		if (GameManager.instance.mode == LevelsMode.Default)
		{
			uiObjective.SetActive(true);
		}
		else
		{
			uiScore.SetActive(true);
		}
		objectiveText = uiObjective.GetComponent<Text>();
		levelTimer = LevelData.instance.levelTimer;
		objectiveText.text = LevelData.instance.objectiveDescription;

		for (int i = 0; i < LevelData.instance.mainObjectives.Length; i++)
		{
			LevelData.instance.mainObjectives[i].WinEvent += CheckWin;
		}

		switch (LevelData.instance.cameraPosition)
		{
			case CameraPosition.Default:
				Camera.main.transform.localPosition = new Vector3(0.83f, 28.86f, -29.54f);
				break;
			case CameraPosition.Near:
				Camera.main.transform.localPosition = new Vector3(0.83f, 23.14f, -26.24f);
				break;
			case CameraPosition.Far:
				Camera.main.transform.localPosition = new Vector3(0.83f, 41.56f, -36.88f);
				break;
			default:
				break;
		}
	}
	/*
	void MenuNavigation()
	{
		if (gameEnd == true)
		{
			if (index == 1)
			{
				Button bM = GameObject.Find("MenuButton").GetComponent<Button>();
				ColorBlock colors = bM.colors;
				colors.normalColor = Color.green;
				bM.colors = colors;

				Button bR = GameObject.Find("RestartButton").GetComponent<Button>();
				ColorBlock colors2 = bR.colors;
				colors2.normalColor = Color.white;
				bR.colors = colors2;

				if (Input.GetKeyDown(KeyCode.Return))
				{
					Menu();
				}
			}
			else if (index == 0)
			{
				Button bM = GameObject.Find("MenuButton").GetComponent<Button>();
				ColorBlock colors = bM.colors;
				colors.normalColor = Color.white;
				bM.colors = colors;

				Button bR = GameObject.Find("RestartButton").GetComponent<Button>();
				ColorBlock colors2 = bR.colors;
				colors2.normalColor = Color.green;
				bR.colors = colors2;

				if (loose == false)
				{
					Button bC = GameObject.Find("NextButton").GetComponent<Button>();
					ColorBlock colors3 = bC.colors;
					colors3.normalColor = Color.white;
					bC.colors = colors3;
				}

				if (Input.GetKeyDown(KeyCode.Return))
				{
					Restart();
				}
			}
			else if (index == -1)
			{
				Button bM = GameObject.Find("MenuButton").GetComponent<Button>();
				ColorBlock colors = bM.colors;
				colors.normalColor = Color.white;
				bM.colors = colors;

				Button bR = GameObject.Find("RestartButton").GetComponent<Button>();
				ColorBlock colors2 = bR.colors;
				colors2.normalColor = Color.white;
				bR.colors = colors2;

				Button bC = GameObject.Find("NextButton").GetComponent<Button>();
				ColorBlock colors3 = bC.colors;
				colors3.normalColor = Color.green;
				bC.colors = colors3;

				if (Input.GetKeyDown(KeyCode.Return))
				{
					NextLevel();
				}
			}

		}
	}
	*/
	protected virtual void Update()
	{
		if (gameEnd == false && Time.timeScale != 0)
		{
			UpdateTimer();
		}
		
		if (Input.GetKeyDown(KeyCode.F2))
		{
			StartCoroutine(Win());
		}
		if (Input.GetKeyDown(KeyCode.F3))
		{
			Lose();
		}
		if (Input.GetKeyDown(KeyCode.F4))
		{
			EndDestruction();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			Utility.Restart();
		}
	}

	void UpdateTimer()
	{
		if (levelTimer <= 0)
		{
			if (GameManager.instance.mode == LevelsMode.Default)
			{
				Lose();
			}
			else
			{
				EndDestruction();
			}
		}
		else
		{
			if (levelTimer <= LevelData.instance.levelTimer / 2 && !hasReminded)
			{
				hasReminded = true;
				if (GameManager.instance.mode == LevelsMode.Default)
					objectiveAnimator.SetTrigger("Remind");
			}
			if (levelTimer <= 10)
			{
				if (!lastSeconds)
				{
					//if (GameManager.instance.mode == LevelsMode.Default)
					//{
						objectiveAnimator.SetTrigger("Remind");
						objectiveText.color = Color.red;
					//}
					lastSeconds = true;
					Time.timeScale = timerAcceleration;
					firstTimerText.color = Color.red;
					secondTimerText.color = Color.red;
					thirdTimerText.color = Color.red;
					fourthTimerText.color = Color.red;
				}
			}


			levelTimer -= Time.unscaledDeltaTime;
		}
		firstTimerText.text = Mathf.Max(Mathf.FloorToInt(levelTimer / 10), 0).ToString();
		secondTimerText.text = Mathf.Max(Mathf.FloorToInt(levelTimer % 10), 0).ToString();
		thirdTimerText.text = Mathf.Max(Mathf.FloorToInt((levelTimer % 1) * 10), 0).ToString();
		fourthTimerText.text = Mathf.Max(Mathf.FloorToInt((levelTimer % 0.1f) * 100), 0).ToString();
	}

	public void CheckWin()
	{
		if (GameManager.instance.mode == LevelsMode.Destruction) return;

		for (int i = 0; i < LevelData.instance.mainObjectives.Length; i++)
		{
			if (!LevelData.instance.mainObjectives[i].validated)
			{
				return;
			}
		}
		StartCoroutine(Win());
	}

	protected virtual IEnumerator Win()
	{
		if (!gameEnd)
		{
			yield return new WaitForSeconds(1);
			gameEnd = true;
            uiWin.SetActive(true);
            Time.timeScale = 0;

            SaveManager.instance.SaveProgress(LevelData.instance.id, true, LevelData.instance.secondaryObjectives);
			LevelData.instance = null;
			SpawnPoint.instance = null;

            //SceneManager.LoadScene("VictoryScreen");
        }
		else
		{
			yield return null;
		}
	}

	void Lose()
	{
		gameEnd = true;
		uiLose.SetActive(true);
		Time.timeScale = 0;

		SaveManager.instance.SaveProgress(LevelData.instance.id, false, LevelData.instance.secondaryObjectives);
		LevelData.instance = null;
		SpawnPoint.instance = null;

        //SceneManager.LoadScene("DefeatScreen");

        //if (Input.GetKeyDown(KeyCode.Return) && index == 1)
        //{
        //	Menu();
        //}
    }

	void EndDestruction()
	{
		gameEnd = true;
		uiDestructionEnd.SetActive(true);
		Time.timeScale = 0;

		SaveManager.instance.SaveDestructionProgress(LevelData.instance.id, DestructionManager.instance.destructionScore);
		LevelData.instance = null;
		SpawnPoint.instance = null;
	}

	//public void Restart()
	//{
	//	Time.timeScale = 1;
	//	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	//}

	//public void Menu()
	//{
	//	Time.timeScale = 1;
	//	SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
	//}

	//public void NextLevel()
	//{
	//	Time.timeScale = 1;
	//	int progression = SaveManager.instance.currentSave.progressionIndex;
	//	if (progression < SaveManager.instance.currentSave.levels.Length)
	//	{
	//		SceneManager.LoadScene(progression + 1);
	//	}
	//}
}
