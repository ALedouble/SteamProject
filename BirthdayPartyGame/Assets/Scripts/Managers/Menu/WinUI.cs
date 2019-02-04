using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : PanelUI {


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
