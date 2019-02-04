using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructionEndUI : PanelUI {

	public Text finalScoreText;

	protected override void Start()
	{
		base.Start();
		finalScoreText.text = DestructionManager.instance.destructionScore.ToString();
	}

	protected override void ClickButton()
	{
		switch (selectIndex)
		{
			case 0:
				Utility.NextLevel();
				break;

			case 1:
				Utility.Restart();
				break;

			case 2:
				Utility.Menu();
				break;
		}
	}

}
