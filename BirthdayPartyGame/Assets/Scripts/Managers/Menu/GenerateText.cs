using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateText : MonoBehaviour {

	public Transform self;
	public GameObject[] textGO;
	float currentPosX;
	public float enlargement = 0.5f;
	



	// Use this for initialization
	void Start () {
		for (int i = 0; i < textGO.Length; i++){
			Vector3 positionLetter = transform.position - transform.right*currentPosX;
			Instantiate(textGO[i], positionLetter, self.rotation, self);
			currentPosX = currentPosX + enlargement;
		}
	}
	
	// Update is called once per frame
	void Update () {
		currentPosX = currentPosX + enlargement;
	}
}
