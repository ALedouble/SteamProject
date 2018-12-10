using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : Interactable
{
	protected Interactable main;

	public void Initialize(Interactable _creator)
	{
		main = _creator;
	}

	public override void Die()
	{
		main.Die();
	}

}
