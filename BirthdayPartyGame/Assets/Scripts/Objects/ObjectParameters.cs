using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActivationType
{
	None,
	Proximity,
	Handheld
}

public enum ObjectMaterial
{
	None,
	Paper,
	Wood,
	Metal
}

[System.Serializable]
public class ObjectParameters : MonoBehaviour {

	public string objectName;
	public bool blunt;
	public bool breakable;
	public bool destructible;
	public bool pickUp;
	public bool electronic;
	public bool isElectric;
	public bool isFire;
	public bool isWater;
	public ActivationType activationType;
	public ObjectMaterial material;
	public Vector3 holdPositionOffset;
	public Vector3 holdRotationOffset;
	public Transform node;

}
