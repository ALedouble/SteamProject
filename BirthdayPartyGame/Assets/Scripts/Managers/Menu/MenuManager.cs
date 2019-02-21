using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public static MenuManager instance;

	public int choose = 0;

    [Space]
    [Header("Referencies")]
	public OptionsManager optionsObject;
	public GameObject[] allElements;
    public Animator cameraAnim;
    public GameObject loadingUIContainer;
    public GameObject levelSelectUIContainer;
    public AudioSource levelAudioSource;
    public AudioClip clipChangeSelectedButton;
    public AudioClip clipValidateSelectedButton;
    public AudioClip clipExitGame;


	MeshRenderer[] meshTextRed;

	MeshRenderer[] meshTextWhite;

	MeshRenderer[] meshTextWhite2;
	MeshRenderer[] meshTextWhite3;
	MeshRenderer[] meshTextWhite4;


	float padMoveUpTimer;
	float padMoveDownTimer;


    private void Start()
    {
		print("Menu START");
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
        Invoke("SetNewMeshesInRed", 0.05f);
		if (GameManager.instance.startMenuOnLevelSelection)
		{
			print("GoToLevelSelection START");
			GameManager.instance.startMenuOnLevelSelection = false;
			cameraAnim.SetBool("SelectBool", true);
			levelSelectUIContainer.SetActive(true);
			print("GoToLevelSelection DONE");
		}
    }

    void Update()
	{
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Grab"))
        {
            SelectCategory();
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Back"))
        {
            if(!cameraAnim.GetBool("SettingsBool") && !cameraAnim.GetBool("SelectBool"))
            {
                print("QUIT");
                Application.Quit();
                levelAudioSource.PlayOneShot(clipExitGame);
            }
        }

		//if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.2f && padMoveUpTimer <= 0))
		//{
		//	GameManager.instance.ToggleDestructionMode();
		//	padMoveUpTimer = Constants.constants.gamepadMoveTimer;
		//}
		//if (padMoveUpTimer > 0)
		//{
		//	padMoveUpTimer -= Time.unscaledDeltaTime;
		//}

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
            levelAudioSource.PlayOneShot(clipChangeSelectedButton);

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
            levelAudioSource.PlayOneShot(clipChangeSelectedButton);

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

    public void SelectCategory()
	{
		switch (choose)
		{
			case 0:
                levelAudioSource.PlayOneShot(clipValidateSelectedButton);
                StartCoroutine(ContinueAsync());
				break;
			case 1:
                levelAudioSource.PlayOneShot(clipValidateSelectedButton);
                cameraAnim.SetBool("SelectBool", true);
                levelSelectUIContainer.SetActive(true);
                break;
			case 2:
                levelAudioSource.PlayOneShot(clipValidateSelectedButton);
                cameraAnim.SetBool("SettingsBool", true);
                break;
			case 3:
                levelAudioSource.PlayOneShot(clipExitGame);
                Application.Quit();
				break;
			default:
				break;
		}
	}

    IEnumerator ContinueAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SaveManager.instance.currentSave.progressionIndex + 1);
        loadingUIContainer.SetActive(true);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            print(asyncLoad.progress);
            yield return null;
        }
    }
}
