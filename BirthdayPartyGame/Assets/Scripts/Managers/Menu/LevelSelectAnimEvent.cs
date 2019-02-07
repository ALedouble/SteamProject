using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectAnimEvent : MonoBehaviour {

    public LevelSelectionManager myLevelSelectMan;

	public void Closed()
    {
        myLevelSelectMan.uiOpened = false;
        myLevelSelectMan.cameraAnim.SetBool("SelectBool", false);
    }

    public void Opened()
    {
        myLevelSelectMan.uiOpened = true;
    }
}
