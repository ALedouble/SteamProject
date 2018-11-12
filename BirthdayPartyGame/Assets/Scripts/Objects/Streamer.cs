using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streamer : Interactable {

	public StreamerChild[] children;
	Vector3[] childrenPos;
	public LineRenderer line;


	private void Start()
	{
		StartCoroutine(CalculateLines());
	}

	IEnumerator CalculateLines()
	{
		print(children.Length);
		Vector3[] points = new Vector3[children.Length];
		for (int i = 0; i < children.Length; i++)
		{
			points[i] = children[i].pos;
		}
		line.SetPositions(points);
		yield return new WaitForSeconds(Time.deltaTime);
		StartCoroutine(CalculateLines());
	}

}
