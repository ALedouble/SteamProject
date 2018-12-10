using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streamer : MonoBehaviour {

	StreamerChild[] children;

	private void Start()
	{
		Transform firstChild = transform.GetChild(0);
		children = new StreamerChild[firstChild.childCount];
		for (int i = 0; i < children.Length; i++)
		{
			children[i] = firstChild.GetChild(i).GetComponent<StreamerChild>();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Interactable" && other.GetComponent<ObjectParameters>().objectName == "Lawnmower")
		{
			GetCut();
		}
	}

	void GetCut()
	{

	}
}
