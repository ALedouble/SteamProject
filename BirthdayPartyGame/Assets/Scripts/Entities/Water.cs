using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Entity {

	protected override void Start()
	{
		base.Start();
		radius = 2;
		maturingTime = 0.1f;
	}

	protected override void Interact(Interactable _object)
	{
		if (_object.parameters.material == ObjectMaterial.Paper)
		{
			canSpreadObjects.Add(_object);
		}
		else if (_object.parameters.material == ObjectMaterial.Wood && _object.burning)
		{
			print("Watering: " + _object);
			_object.StopBurning();
		}
	}
	protected override void Spread()
	{
		for (int i = 0; i < canSpreadObjects.Count; i++)
		{
			canSpreadObjects[i].GetWet();
		}
	}

}
