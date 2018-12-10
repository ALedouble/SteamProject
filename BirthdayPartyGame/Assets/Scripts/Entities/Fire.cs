using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Entity {

	private void Awake()
	{
		radius = 2f;
		//maturingTime = 1.5f;
	}

	protected override void Interact(Node _object)
	{
		if ((_object.parameters.material == ObjectMaterial.Wood || _object.parameters.material == ObjectMaterial.Paper) &&
					(!_object.wet && !_object.burning))
		{
			canSpreadObjects.Add(_object);
		}
	}

	protected override void Spread()
	{
		for (int i = 0; i < canSpreadObjects.Count; i++)
		{
			canSpreadObjects[i].Burn();
		}
	}

}
