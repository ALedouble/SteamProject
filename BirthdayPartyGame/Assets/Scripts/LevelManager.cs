using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public float levelTimer = 60;
	public Text timerText;
	public GameObject uiWin;
	public GameObject uiLose;
	bool gameEnd;

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
		Time.timeScale = 0;
		uiWin.SetActive(true);
	}

	void Lose()
	{
		print("Loser!");
		gameEnd = true;
		Time.timeScale = 0;
		uiLose.SetActive(true);
	}
}
