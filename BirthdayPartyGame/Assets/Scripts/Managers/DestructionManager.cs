using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructionManager : MonoBehaviour {

	public static DestructionManager instance;

	public float destructionScore;

	[Header("References: ")]
	public Text destructionText;

	// Use this for initialization
	void Awake () {
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
		}
	}
	
	public void AddDestruction(float _amount)
	{
		destructionScore += _amount;
		UpdateDestructionUI();
	}

	void UpdateDestructionUI()
	{
		destructionText.text = "Destruction: " + destructionScore;
	}
}
