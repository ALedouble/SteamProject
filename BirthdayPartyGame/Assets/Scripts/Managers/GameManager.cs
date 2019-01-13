using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DevState
{
	Test,
	Debug
}

public class GameManager : MonoBehaviour {

	static public GameManager instance;

	public DevState state = DevState.Test;

	// Use this for initialization
	void Start () {
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F1))
		{
			if (state == DevState.Test)
			{
				state = DevState.Debug;
			}
			else
			{
				state = DevState.Test;
			}
		}
	}
}
