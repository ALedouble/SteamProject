using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectAnimEvent : MonoBehaviour {

    public LevelSelectionManager myLevelSelectMan;
    public AudioSource levelAudioSource;
    public AudioClip closingPanelClip;
    public AudioClip openingPanelClip;
    public AudioClip possibleInputAppearingClip;

    public void Closed()
    {
        myLevelSelectMan.uiOpened = false;
        myLevelSelectMan.cameraAnim.SetBool("SelectBool", false);
    }

    public void Opened()
    {
        myLevelSelectMan.uiOpened = true;
    }

    public void PlayClosingPanelSound()
    {
        levelAudioSource.PlayOneShot(closingPanelClip);
    }

    public void PlayOpeningPanelSound()
    {
        levelAudioSource.PlayOneShot(openingPanelClip);
    }

    public void PlayInputAppearingSound()
    {
        levelAudioSource.PlayOneShot(possibleInputAppearingClip);
    }
}
