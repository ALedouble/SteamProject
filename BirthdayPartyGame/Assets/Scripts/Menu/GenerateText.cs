using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateText : MonoBehaviour {

	public Transform self;
	public GameObject[] textGO;
	float currentPosX;
	



	// Use this for initialization
	void Start () {
		for (int i = 0; i < textGO.Length; i++){
			Vector3 positionLetter = new Vector3( transform.position.x - currentPosX, transform.position.y , transform.position.z);
			Instantiate(textGO[i], positionLetter, Quaternion.identity, self);
			currentPosX = currentPosX + 0.5f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
