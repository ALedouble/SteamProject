using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	int choose = 0;
	public OptionsManager optionsObject;
	public GameObject[] allElements;
    public Transform[] sectionTransform;
    


	MeshRenderer[] meshTextRed;

	MeshRenderer[] meshTextWhite;

	MeshRenderer[] meshTextWhite2;
	MeshRenderer[] meshTextWhite3;
	MeshRenderer[] meshTextWhite4;


	float padMoveUpTimer;
	float padMoveDownTimer;


    private void Start()
    {
        Invoke("SetNewMeshesInRed", 0.05f);
    }

    void Update()
	{
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Grab"))
        {
            SelectCategory();
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Back"))
        {
            Application.Quit();
        }

        UpdatePadMoveTimers();
        MenuNavigation();
	}

    void UpdatePadMoveTimers()
    {
        if (padMoveUpTimer > 0)
        {
            padMoveUpTimer -= Time.unscaledDeltaTime;
        }
        if (padMoveDownTimer > 0)
        {
            padMoveDownTimer -= Time.unscaledDeltaTime;
        }
    }

	void MenuNavigation()
	{
        //ADD IF SELECT LEVEL MANAGER != NULL RETURN
		if (optionsObject.opened == true) return;

        //MENU GOING DOWN
		if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetAxisRaw("Vertical") < -0.2f && padMoveDownTimer <= 0))
		{
			choose += 1;


			if (choose > 3)
			{
				choose = 0;
			}
            SetNewMeshesInRed();
            padMoveDownTimer = Constants.constants.gamepadMoveTimer;
			padMoveUpTimer = 0;
		}

        //MENU GOING UP
		if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetAxisRaw("Vertical") > 0.2f && padMoveUpTimer <= 0))
		{
			choose -= 1;

			if (choose < 0)
			{
				choose = 3;
            }
            SetNewMeshesInRed();
            padMoveUpTimer = Constants.constants.gamepadMoveTimer;
			padMoveDownTimer = 0;
		}

        //RESET GAMEPAD JOYSTICK
		if (Mathf.Abs(Input.GetAxisRaw("Vertical")) < 0.2f)
		{
			padMoveUpTimer = 0;
			padMoveDownTimer = 0;
		}		
    }

    void SetNewMeshesInRed()
    {
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

        meshTextRed = allElements[choose].GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer colorful in meshTextRed)
        {
            colorful.material.color = Color.red;
        }
    }

    void SelectCategory()
	{
		switch (choose)
		{
			case 0:
				SceneManager.LoadScene(SaveManager.instance.currentSave.progressionIndex + 1);
				break;
			case 1:
                /*Camera.main.transform.position = sectionTransform[1].position;
                Camera.main.transform.rotation = sectionTransform[1].rotation;*/
                SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
                break;
			case 2:
                Camera.main.transform.position = sectionTransform[2].position;
                Camera.main.transform.rotation = sectionTransform[2].rotation;
                optionsObject.opened = true;
                optionsObject.optionAnim.SetBool("Open", optionsObject.opened);
                break;
			case 3:
				Application.Quit();
				break;
			default:
				break;
		}

	}
}
