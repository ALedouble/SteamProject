using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	int choose = 0;
	public GameObject optionsObject;
	public GameObject[] allElements;


	MeshRenderer[] meshTextRed;

	MeshRenderer[] meshTextWhite;

	MeshRenderer[] meshTextWhite2;
	MeshRenderer[] meshTextWhite3;
	MeshRenderer[] meshTextWhite4;


	float padMoveUpTimer;
	float padMoveDownTimer;


	// Update is called once per frame
	void Update()
	{
		if (padMoveUpTimer > 0)
		{
			padMoveUpTimer -= Time.unscaledDeltaTime;
		}
		if (padMoveDownTimer > 0)
		{
			padMoveDownTimer -= Time.unscaledDeltaTime;
		}

		MenuNavigation();
	}

	void MenuNavigation()
	{
		if (OptionsManager.instance != null) return;
		if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetAxisRaw("Vertical") < -0.2f && padMoveDownTimer <= 0))
		{
			choose += 1;


			if (choose > 3)
			{
				choose = 0;
			}

			padMoveDownTimer = Constants.constants.gamepadMoveTimer;
			padMoveUpTimer = 0;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetAxisRaw("Vertical") > 0.2f && padMoveUpTimer <= 0))
		{
			choose -= 1;

			if (choose < 0)
			{
				choose = 3;
			}

			padMoveUpTimer = Constants.constants.gamepadMoveTimer;
			padMoveDownTimer = 0;
		}
		if (Mathf.Abs(Input.GetAxisRaw("Vertical")) < 0.2f)
		{
			padMoveUpTimer = 0;
			padMoveDownTimer = 0;
		}

		meshTextRed = allElements[choose].GetComponentsInChildren<MeshRenderer>();

		foreach (MeshRenderer colorful in meshTextRed)
		{
			colorful.material.color = Color.red;
		}


		if (choose < 3)
		{
			meshTextWhite = allElements[choose + 1].GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer colorful in meshTextWhite)
			{
				colorful.material.color = Color.white;
			}
		}

		if (choose > 0)
		{
			meshTextWhite2 = allElements[choose - 1].GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer colorful in meshTextWhite2)
			{
				colorful.material.color = Color.white;
			}
		}

		if (choose == 0)
		{
			meshTextWhite3 = allElements[choose + 3].GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer colorful in meshTextWhite3)
			{
				colorful.material.color = Color.white;
			}
		}

		if (choose == 3)
		{
			meshTextWhite4 = allElements[choose - 3].GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer colorful in meshTextWhite4)
			{
				colorful.material.color = Color.white;
			}
		}

		if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Grab"))
		{
			switch (choose)
			{
				case 0:
					SceneManager.LoadScene(SaveManager.instance.currentSave.progressionIndex + 1);
					break;
				case 1:
					SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
					break;
				case 2:
					optionsObject.SetActive(true);
					break;
				case 3:
					Application.Quit();
					break;
				default:
					break;
			}

		}

		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Back"))
		{
			Application.Quit();
		}
	}


	/* IEnumerator LoadScene()
	 {
		 transitionAnim.SetTrigger("end");
		 yield return new WaitForSeconds(1.3f);
		 SceneManager.LoadScene("VerticalSliceScene 1", LoadSceneMode.Single);
	 }

	 */
}
