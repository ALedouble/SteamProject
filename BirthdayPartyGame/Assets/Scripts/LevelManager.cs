using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float levelTimer = 60;
	public Text timerText;
	public GameObject uiWin;
	public GameObject uiLose;
	protected bool gameEnd;

	protected virtual void Update()
	{
		if (gameEnd) return;
		UpdateTimer();
	}

	void UpdateTimer()
	{
		if (levelTimer <= 0)
		{
			Lose();
		}
		else
		{
			levelTimer -= Time.deltaTime;
		}
		timerText.text = levelTimer.ToString("#.##");
	}

	public virtual void CheckWin() { }

	protected virtual void Win()
	{
		print("Winning!");
		gameEnd = true;
		//Time.timeScale = 0.01f;
		uiWin.SetActive(true);
	}

	void Lose()
	{
		print("Loser!");
		gameEnd = true;
		//Time.timeScale = 0.01f;
		uiLose.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void NextLevel()
	{
		SceneManager.LoadScene("Menu");
	}
}
