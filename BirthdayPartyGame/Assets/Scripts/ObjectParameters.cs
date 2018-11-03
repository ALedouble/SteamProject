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

	public bool blunt;
	public bool breakable;
	public bool destructible;
	public bool pickUp;
	public bool electronic;
	public bool electric;
	public ActivationType activationType;
	public ObjectMaterial material;

}
