using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsManager : MonoBehaviour {

	public static OptionsManager instance;

    [Space]
    [Header("Referencies")]
	public AudioMixer audioMixer;
    public Animator cameraAnim;
    public Animator optionAnim;
    public Slider volumeSlider;
	public Text volumeText;
    public AudioSource levelAudioSource;
    public AudioClip closingPanelClip;
    public AudioClip openingPanelClip;

    [HideInInspector]
    public bool opened;

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
		UpdateVolumeSlider(GetMixerValue());
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Back"))
		{
			CloseOptions();
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
		Screen.fullScreenMode = FullScreenMode.Windowed;
	}

	void DisableWindowed()
	{
		Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
	}

	public void UpdateVolumeValue()
	{
		audioMixer.SetFloat("Volume", volumeSlider.value - 80);
		volumeText.text = "Volume: " + volumeSlider.value.ToString("#");
	}

	void UpdateVolumeSlider(float _newVolume)
	{
		volumeSlider.value = _newVolume;
		volumeText.text = "Volume: " + _newVolume.ToString("#");
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
