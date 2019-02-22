﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsManager : PanelUI {

	public static OptionsManager instance;

    [Space]
    [Header("Referencies")]
	public AudioMixer audioMixer;
    public Animator cameraAnim;
    public Animator optionAnim;
    public AudioSource levelAudioSource;
    public AudioClip closingPanelClip;
    public AudioClip openingPanelClip;

	[Space]
	[Header("UI: ")]
	public Image fullscreenIcon;
	public Slider volumeSlider;
	public Text volumeText;

	[HideInInspector]
    public bool opened;
	[Space]
	public float volumeChangeSpeed = 30;

	//float padMoveRightTimer;
	//float padMoveLeftTimer;

	private void OnEnable()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		if (Screen.fullScreen)
		{
			fullscreenIcon.sprite = Constants.constants.checkedIcon;
		}
		else
		{
			fullscreenIcon.sprite = Constants.constants.emptyIcon;
		}
		UpdateVolumeSlider(GetMixerValue());
	}

	//protected override void Start()
	//{
	//	//buttonText = new Text[buttons.Length];
	//	//for (int i = 0; i < buttonText.Length; i++)
	//	//{
	//	//	buttonText[i] = buttons[i].GetComponentInChildren<Text>();
	//	//}
	//	UpdateIndex(0);
	//}

	protected override void Update()
	{
		//if (padMoveRightTimer > 0)
		//{
		//	padMoveRightTimer -= Time.unscaledDeltaTime;
		//}
		//if (padMoveLeftTimer > 0)
		//{
		//	padMoveLeftTimer -= Time.unscaledDeltaTime;
		//}
		base.Update();
	}

	protected override void GetInput()
	{
		base.GetInput();


		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Back"))
		{
			CloseOptions();
		}
		if (selectIndex == 1)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetAxisRaw("Horizontal") > 0.2f /*&& padMoveRightTimer <= 0*/))
			{
				UpdateVolumeSlider(Mathf.Clamp(GetMixerValue() + (volumeChangeSpeed * Time.deltaTime), 0, 100));
				//UpdateIndex(-1);
				//padMoveRightTimer = Constants.constants.gamepadMoveTimer;
				//padMoveLeftTimer = 0;
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetAxisRaw("Horizontal") < -0.2f /*&& padMoveLeftTimer <= 0*/))
			{
				UpdateVolumeSlider(Mathf.Clamp(GetMixerValue() - (volumeChangeSpeed * Time.deltaTime), 0, 100));
				//UpdateIndex(1);
				//padMoveLeftTimer = Constants.constants.gamepadMoveTimer;
				//padMoveRightTimer = 0;
			}
			//if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.2f)
			//{
			//	padMoveRightTimer = 0;
			//	padMoveLeftTimer = 0;
			//}
		}
	}

	//protected override void UpdateIndex(int _amount)
	//{
	//	base.UpdateIndex(_amount);
	//	for (int i = 0; i < buttons.Length; i++)
	//	{
	//		if (i == selectIndex)
	//		{
	//			buttons[i].image.enabled = true;
	//		}
	//		else
	//		{
	//			buttons[i].image.enabled = false;
	//		}
	//	}
	//}

	protected override void ClickButton()
	{
		switch (selectIndex)
		{
			case 0:
				ToggleWindowed();
				break;

			default:
				break;
		}
	}

	private void OnDisable()
	{
        instance = null;
	}

	public void CloseOptions()
    {
        opened = false;
        optionAnim.SetBool("Open", opened);
    }

	public void ToggleWindowed()
	{
		if (Screen.fullScreen)
		{
			EnableWindowed();
		}
		else
		{
			DisableWindowed();
		}
	}

	void EnableWindowed()
	{
		fullscreenIcon.sprite = Constants.constants.emptyIcon;
		Screen.fullScreenMode = FullScreenMode.Windowed;
	}

	void DisableWindowed()
	{
		fullscreenIcon.sprite = Constants.constants.checkedIcon;
		Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
	}

	public void UpdateVolumeValue()
	{
		audioMixer.SetFloat("Volume", volumeSlider.value - 80);
		//volumeText.text = "Volume: " + volumeSlider.value.ToString("#");
	}

	void UpdateVolumeSlider(float _newVolume)
	{
		volumeSlider.value = _newVolume;
		//volumeText.text = "Volume: " + _newVolume.ToString("#");
		UpdateVolumeValue();
	}

	float GetMixerValue()
	{
		float _volume;
		audioMixer.GetFloat("Volume", out _volume);
		return _volume + 80;
	}

    public void ExitCameraAnimation()
    {
        cameraAnim.SetBool("SettingsBool", false);
    }

    public void LaunchingOpenAnim()
    {
        opened = true;
        optionAnim.SetBool("Open", opened);
    }

    public void PlayClosingPanelSound()
    {
        levelAudioSource.PlayOneShot(closingPanelClip);
    }

    public void PlayOpeningPanelSound()
    {
        levelAudioSource.PlayOneShot(openingPanelClip);
    }

}
