using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public enum PauseState
{
	Default,
	Pause
}

public class PauseManager : MonoBehaviour {

	LevelManager levelManager;
	public AudioMixer audioMixer;

	public PauseState state = PauseState.Default;

	public GameObject pauseObject;
	public Button[] buttons;
	public GameObject optionsObject;
	public Slider volumeSlider;
	public Text volumeText;

	int selectIndex;
	bool optionsOpened;

	// Use this for initialization
	void Start () {
		levelManager = GetComponent<LevelManager>();
		UpdateIndex(0);
		//UpdateVolumeSlider(GetMixerValue());
	}
	
	// Update is called once per frame
	void Update () {
		if (OptionsManager.instance == null)
		{
			GetInput();
		}
	}

	void GetInput()
	{
		//Toggle UI
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//if (optionsOpened)
			//{
			//	CloseOptions();
			//}
			//else
			//{
				TogglePause();
			//}
		}

		//Select button
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			UpdateIndex(-1);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			UpdateIndex(1);
		}

		//Click button
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ClickButton();
		}
	}

	void UpdateIndex(int _amount)
	{
		int _newIndex = selectIndex + _amount;

		if (_newIndex < 0)
		{
			selectIndex = 3;
		}
		else
		{
			selectIndex = (_newIndex) % buttons.Length;
		}

		for (int i = 0; i < buttons.Length; i++)
		{
			if (i == selectIndex)
			{
				buttons[i].GetComponent<Image>().color = Color.green;
			}
			else
			{
				buttons[i].GetComponent<Image>().color = Color.white;
			}
		}
	}

	void ClickButton()
	{
		switch (selectIndex)
		{
			case 0:
				Unpause();
				break;

			case 1:
				OpenOptions();
				break;

			case 2:
				levelManager.Restart();
				break;

			case 3:
				levelManager.Menu();
				break;
		}
	}

	void TogglePause()
	{
		if (state == PauseState.Default)
		{
			Pause();
		}
		else
		{
			Unpause();
		}
	}

	void Pause()
	{
		state = PauseState.Pause;
		pauseObject.SetActive(true);
		Time.timeScale = 0;
	}

	void Unpause()
	{
		state = PauseState.Default;
		pauseObject.SetActive(false);
		Time.timeScale = 1;
	}

	public void OpenOptions()
	{
		optionsObject.SetActive(true);
		optionsOpened = true;
	}

	//public void CloseOptions()
	//{
	//	optionsObject.SetActive(false);
	//	optionsOpened = false;
	//}

	//public void ToggleWindowed()
	//{
	//	if (Screen.fullScreen)
	//	{
	//		EnableWindowed();
	//	}
	//	else
	//	{
	//		DisableWindowed();
	//	}
	//}

	//void EnableWindowed()
	//{
	//	Screen.fullScreenMode = FullScreenMode.Windowed;
	//}

	//void DisableWindowed()
	//{
	//	Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
	//}

	//public void UpdateVolumeValue()
	//{
	//	audioMixer.SetFloat("Volume", volumeSlider.value - 80);
	//	volumeText.text = "Volume: " + volumeSlider.value.ToString("#");
	//}

	//void UpdateVolumeSlider(float _newVolume)
	//{
	//	volumeSlider.value = _newVolume;
	//	volumeText.text = "Volume: " + _newVolume.ToString("#");
	//	UpdateVolumeValue();
	//}

	//float GetMixerValue()
	//{
	//	float _volume;
	//	audioMixer.GetFloat("Volume", out _volume);
	//	return _volume + 80;
	//}
}
