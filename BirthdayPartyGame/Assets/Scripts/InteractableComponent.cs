﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableComponent : MonoBehaviour {

	protected Interactable main;

	public void Initialize(Interactable _creator)
	{
		main = _creator;
	}

}
