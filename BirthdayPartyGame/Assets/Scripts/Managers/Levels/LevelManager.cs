using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	float levelTimer = 60;
	public Text firstTimerText;
	public Text secondTimerText;
	public Text thirdTimerText;
	public Text fourthTimerText;
	public Text objectiveText;
	public GameObject uiWin;
	public GameObject uiLose;
	public Animator objectiveAnimator;
	protected bool gameEnd;
	int index = 0;
	bool loose = false;
	bool hasReminded;
	bool lastSeconds;
	public float timerAcceleration = 1.5f;

	
	private void Start()
	{
		levelTimer = LevelData.instance.levelTimer;
		objectiveText.text = LevelData.instance.objectiveDescription;
	}

	void FixedUpdate() {
		if (gameEnd == true){
			if(index == 1){
				Button bM = GameObject.Find("MenuButton").GetComponent<Button>();
				ColorBlock colors = bM.colors;
				colors.normalColor = Color.green;
				bM.colors = colors;

				Button bR = GameObject.Find("RestartButton").GetComponent<Button>();
				ColorBlock colors2 = bR.colors;
				colors2.normalColor = Color.white;
				bR.colors = colors2;

				if(Input.GetKeyDown(KeyCode.Return)){
					Menu();
				}
			}
			else if(index == 0){
					Button bM = GameObject.Find("MenuButton").GetComponent<Button>();
					ColorBlock colors = bM.colors;
					colors.normalColor = Color.white;
					bM.colors = colors;

					Button bR = GameObject.Find("RestartButton").GetComponent<Button>();
					ColorBlock colors2 = bR.colors;
					colors2.normalColor = Color.green;
					bR.colors = colors2;

					if (loose == false){
						Button bC = GameObject.Find("NextButton").GetComponent<Button>();
						ColorBlock colors3 = bC.colors;
						colors3.normalColor = Color.white;
						bC.colors = colors3;
					}	 

					if(Input.GetKeyDown(KeyCode.Return)){
						Restart();
					}
			}
			else if (index == - 1)
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
			}
			
		}
	}

	protected virtual void Update()
	{
		if (gameEnd == false){
			UpdateTimer();

			if (LevelData.instance.secondaryObjectives.Length > 0)
			{
				for (int i = 0; i < LevelData.instance.secondaryObjectives.Length; i++)
				{
					if (!LevelData.instance.secondaryObjectives[i].validated)
					{
						LevelData.instance.secondaryObjectives[i].CheckValid();
					}
				}
			}

			CheckWin();
		}
		
		if (loose == true && index == 0){
			index = 0;
		}

		if (gameEnd == true && loose == true){
			if (Input.GetKeyDown(KeyCode.DownArrow) && index < 1){
				index += 1;
			}

			if (Input.GetKeyDown(KeyCode.UpArrow) && index > 0){
				index -= 1;
			}
		}
		else if (gameEnd == true && loose == false){
			if (Input.GetKeyDown(KeyCode.DownArrow) && index < 1){
				index += 1;
			}

			if (Input.GetKeyDown(KeyCode.UpArrow) && index > -1){
				index -= 1;
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("LevelSelection");
		}
	}

	void UpdateTimer()
	{
		if (levelTimer <= 0)
		{
			Lose();
		}
		else
		{
			if (levelTimer <= LevelData.instance.levelTimer/2 && !hasReminded)
			{
				hasReminded = true;
				objectiveAnimator.SetTrigger("Remind");
			}
			if (levelTimer <= 10)
			{
				if (!lastSeconds)
				{
					objectiveAnimator.SetTrigger("Remind");
					lastSeconds = true;
					Time.timeScale = timerAcceleration;
					firstTimerText.color = Color.red;
					secondTimerText.color = Color.red;
					thirdTimerText.color = Color.red;
					fourthTimerText.color = Color.red;
					objectiveText.color = Color.red;
				}
			}
			

			levelTimer -= Time.unscaledDeltaTime;
		}
		firstTimerText.text = Mathf.Max(Mathf.FloorToInt(levelTimer / 10), 0).ToString();
		secondTimerText.text = Mathf.Max(Mathf.FloorToInt(levelTimer % 10), 0).ToString();
		thirdTimerText.text = Mathf.Max(Mathf.FloorToInt((levelTimer % 1) * 10), 0).ToString();
		fourthTimerText.text = Mathf.Max(Mathf.FloorToInt((levelTimer % 0.1f) * 100), 0).ToString();
	}

	public virtual void CheckWin()
	{
        if (LevelData.instance.mainObjectives.Length <= 0)
        {
            return;
        }

		bool won = true;

		for (int i = 0; i < LevelData.instance.mainObjectives.Length; i++)
		{
			LevelData.instance.mainObjectives[i].CheckValid();
			if (!LevelData.instance.mainObjectives[i].validated)
			{
				won = false;
			}
		}

		if (won)
		{
			print("Go to win");
			StartCoroutine(Win());
		}
	}

	protected virtual IEnumerator Win()
	{
		print(gameEnd);
		if (!gameEnd)
		{
			
			//Debug.Log(index);

			yield return new WaitForSeconds(1);
			gameEnd = true;
			//Time.timeScale = 0.01f;
			uiWin.SetActive(true);
			Time.timeScale = 1;

			SaveManager.instance.SaveProgress(LevelData.instance.id, true, LevelData.instance.secondaryObjectives);
			LevelData.instance = null;
		}
		else
		{
			yield return null;
		}
	}

	void Lose()
	{
		loose = true;
		gameEnd = true;
		//Time.timeScale = 0.01f;
		uiLose.SetActive(true);
		Time.timeScale = 1;

		SaveManager.instance.SaveProgress(LevelData.instance.id, false, LevelData.instance.secondaryObjectives);
		LevelData.instance = null;


		if (Input.GetKeyDown(KeyCode.Return) && index == 1){
			Menu();
		}

		Debug.Log(index);
	}

	public void Restart()
	{
		Debug.Log("oui");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu()
	{
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}

	public void NextLevel()
	{
		SceneManager.LoadScene("Menu");
	}
}
