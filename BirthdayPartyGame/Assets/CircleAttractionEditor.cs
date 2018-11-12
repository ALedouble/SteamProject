using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CircleAttraction))]
public class CircleAttractionEditor : Editor {

	// Use this for initialization
	void OnSceneGUI(){
		CircleAttraction ca = (CircleAttraction) target;
		Handles.color = Color.red;
		Handles.DrawWireArc(ca.transform.position, Vector3.up, Vector3.forward, 360, ca.radius);
	}
}
