using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsManager : MonoBehaviour {

	public static OptionsManager instance;

	public AudioMixer audioMixer;

	public Slider volumeSlider;
	public Text volumeText;

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
		if (Input.GetKeyDown(KeyCode.Escape))
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
		gameObject.SetActive(false);
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

}
