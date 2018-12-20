using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTest : LevelManager {

	public Interactable[] toDestroy;

	protected override void Update()
	{
		base.Update();
		CheckWin();
	}

	public override void CheckWin()
	{
		for (int i = 0; i < toDestroy.Length; i++)
		{
			if (toDestroy[i] != null && toDestroy[i].enabled)
			{
				return;
			}
		}
		StartCoroutine(Win());
	}

}
