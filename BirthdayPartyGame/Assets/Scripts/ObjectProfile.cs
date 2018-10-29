using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActivationType
{
	None,
	Proximity,
	Handheld
}

[CreateAssetMenu(fileName = "Object", menuName = "New Object")]
public class ObjectProfile : ScriptableObject {

	public bool blunt;
	public bool breakable;
	public bool pickUp;
	public bool electronic;
	public bool electric;
	public ActivationType activationType;
	
}
