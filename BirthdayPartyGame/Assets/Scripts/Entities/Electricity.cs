using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : Entity {

	public Electricity creator;
	bool creatorInRange;
	public bool firstGeneration;

	protected override void Initialize()
	{
		base.Initialize();
		maturingTime = 0.1f;
	}

	protected override void CheckObjects(Collider[] _colliders)
	{
		creatorInRange = false;
		base.CheckObjects(_colliders);
		if (!creatorInRange && !firstGeneration) main.StopElectrified();
	}

	protected override void Interact(Interactable _object)
	{
		if ((_object.parameters.material == ObjectMaterial.Metal || _object.wet) && !_object.electrified /*&& (_object.electricityScript != creator && _object.electricityScript != null)*/)
			canSpreadObjects.Add(_object);

		if (!firstGeneration)
			if (_object.electrified && _object.electricityScript == creator && _object.electricityScript.enabled) //TO DEBUG: Objects with different sizes mean sometimes one will detect the other but not he other way around
				creatorInRange = true;
	}

	protected override void Spread()
	{
		if (!creatorInRange && !firstGeneration)
		{
			main.StopElectrified();
			return;
		}
		for (int i = 0; i < canSpreadObjects.Count; i++)
		{
			canSpreadObjects[i].GetElectrified(this);
		}
	}

}
