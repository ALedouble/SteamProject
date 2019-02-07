using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraAnimationEvents : MonoBehaviour {

    public OptionsManager optionsObject;
    public LevelSelectionManager levelSelectMan;

    public void LaunchSettingsAnim()
    {
        optionsObject.LaunchingOpenAnim();
    }

    public void LaunchSelectAnim()
    {
        levelSelectMan.LaunchingOpenAnim();
    }
}
