using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseUI : PanelUI {

	protected override void ClickButton()
	{
		switch (selectIndex)
		{
			case 0:
				Utility.Restart();
				break;

			case 1:
				Utility.Menu();
				break;
		}
	}

}
