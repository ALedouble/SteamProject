using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streamer : MonoBehaviour {

	public StreamerChild[] children;
	public LineRenderer line;

	private void Start()
	{
		//Transform firstChild = transform.GetChild(0);
		//children = new StreamerChild[firstChild.childCount];
		for (int i = 0; i < children.Length; i++)
		{
			//children[i] = firstChild.GetChild(i).GetComponent<StreamerChild>();
			children[i].animated = true;
		}
		line.positionCount = children.Length;
	}

	private void Update()
	{

		for (int i = 0; i < children.Length; i++)
		{
			line.SetPosition(i, children[i].pos);
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
		for (int i = 0; i < children.Length; i++)
		{
			children[i].animated = false;
		}
		line.positionCount = 0;
		Destroy(this);
	}
}
