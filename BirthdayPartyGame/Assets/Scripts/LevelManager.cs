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
	int index = -1;
	bool loose = false;

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
			else if (index == - 1 && loose == false)
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
		}
		
		if (loose == true && index == -1){
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

		//Debug.Log(index);
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
		Debug.Log(index);
		
		print("Winning!");
		gameEnd = true;
		//Time.timeScale = 0.01f;
		uiWin.SetActive(true);
	}

	void Lose()
	{
		loose = true;
		print("Loser!");
		gameEnd = true;
		//Time.timeScale = 0.01f;
		uiLose.SetActive(true);

		

		if(Input.GetKeyDown(KeyCode.Return) && index == 1){
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
