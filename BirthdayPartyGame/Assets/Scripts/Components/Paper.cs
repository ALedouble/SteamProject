using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : InteractableComponent {

	float timeToBurnDown = 5;

	private void Update()
	{
		CheckBurnDown();
	}

	void CheckBurnDown()
	{
		if (main.burning)
		{
			if (timeToBurnDown > 0)
			{
				timeToBurnDown -= Time.deltaTime;
			}
			else
			{
				BurnDown();
			}
		}
	}

	void BurnDown()
	{
		main.Die();
	}

}
