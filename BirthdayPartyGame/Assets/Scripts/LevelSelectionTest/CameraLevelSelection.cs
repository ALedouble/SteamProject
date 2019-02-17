using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevelSelection : MonoBehaviour {

    Vector3 wantedPosition;

	// Use this for initialization
	void Start () {
        wantedPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
	}

    void UpdatePosition()
    {
        wantedPosition.x = PlayerController.instance.transform.position.x;
        transform.position = Vector3.Lerp(transform.position, wantedPosition, 0.2f);
    }
}
