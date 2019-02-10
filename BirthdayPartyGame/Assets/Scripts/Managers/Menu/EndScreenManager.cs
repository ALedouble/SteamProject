using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenManager : MonoBehaviour {

	public GameObject endScreenUI;

	// Use this for initialization
	void Start () {
		StartCoroutine(WaitBeforeScreen());
	}

	IEnumerator WaitBeforeScreen()
	{
		yield return new WaitForSeconds(1);
		endScreenUI.SetActive(true);
	}
}
