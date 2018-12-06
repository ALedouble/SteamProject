using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTest : LevelManager {

	public Interactable[] toBurnBanners;

	protected override void Update()
	{
		base.Update();
		CheckWin();
	}

	public override void CheckWin()
	{
		for (int i = 0; i < toBurnBanners.Length; i++)
		{
			if (toBurnBanners[i] != null && toBurnBanners[i].enabled)
			{
				return;
			}
		}
		StartCoroutine(Win());
	}

}
