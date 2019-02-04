using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructionManager : MonoBehaviour {

	public static DestructionManager instance;

	public float destructionScore;

	[Header("References: ")]
	public Transform canvas;
	public Text destructionText;
	public GameObject scorePopUp;

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
	
	public void AddDestruction(Vector3 _position, float _amount)
	{
		destructionScore += _amount;
		UpdateDestructionUI();
		SpawnDestructionPopUp(_position, _amount);
	}

	void UpdateDestructionUI()
	{
		destructionText.text = "Destruction: " + destructionScore;
	}

	void SpawnDestructionPopUp(Vector3 _position, float _amount)
	{
		Vector3 newPos = Utility.AddOffset(Utility.ConvertUI(_position), new Vector3(Random.Range(-10f, 10), 20 + Random.Range(-10f, 10f), 0));
		Text newPopUp = Instantiate(scorePopUp, newPos, Quaternion.identity, canvas).GetComponent<Text>();
		float relativeAmount = (_amount / 100);
		newPopUp.fontSize = 10 + (int)(relativeAmount * 40);
		print("FontSize = " + newPopUp.fontSize);
		newPopUp.color = Color.Lerp(Color.white, Color.yellow, relativeAmount);
		print("Color = " + newPopUp.color);
		newPopUp.text = "+" + _amount;
		newPopUp.GetComponent<PopUpController>().Initialize(1.0f);
	}
}
