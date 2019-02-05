using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraAnimationEvents : MonoBehaviour {

    public OptionsManager optionsObject;

    public void LaunchSettingsAnim()
    {
        optionsObject.opened = true;
        optionsObject.optionAnim.SetBool("Open", optionsObject.opened);
    }
}
