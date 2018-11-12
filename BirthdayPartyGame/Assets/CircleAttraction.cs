using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAttraction : MonoBehaviour {
	public float radius;

	public Vector3 DirFromAngle(float angleDegrees){
		return new Vector3(Mathf.Sin(angleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleDegrees = Mathf.Deg2Rad));
	}
}