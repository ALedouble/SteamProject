using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelUI : MonoBehaviour {

	protected int selectIndex;
	public Button[] buttons;

	protected virtual void Start()
	{
		UpdateIndex(0);
	}

	// Update is called once per frame
	protected virtual void Update () {
		GetInput();
	}

	protected virtual void GetInput()
	{
		//Select button
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			UpdateIndex(-1);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			UpdateIndex(1);
		}

		//Click button
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ClickButton();
		}
	}

	protected void UpdateIndex(int _amount)
	{
		int _newIndex = selectIndex + _amount;

		if (_newIndex < 0)
		{
			selectIndex = buttons.Length-1;
		}
		else
		{
			selectIndex = (_newIndex) % buttons.Length;
		}

		for (int i = 0; i < buttons.Length; i++)
		{
			if (i == selectIndex)
			{
				buttons[i].GetComponent<Image>().color = Color.green;
			}
			else
			{
				buttons[i].GetComponent<Image>().color = Color.white;
			}
		}
	}

	protected virtual void ClickButton() {}

}
