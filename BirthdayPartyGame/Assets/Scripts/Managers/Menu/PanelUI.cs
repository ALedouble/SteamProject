using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelUI : MonoBehaviour {

	protected int selectIndex;
	public Button[] buttons;
	Text[] buttonText;
	float padMoveUpTimer;
	float padMoveDownTimer;

	protected virtual void Start()
	{
		buttonText = new Text[buttons.Length];
		for (int i = 0; i < buttonText.Length; i++)
		{
			buttonText[i] = buttons[i].GetComponentInChildren<Text>();
		}
		UpdateIndex(0);
	}

	// Update is called once per frame
	protected virtual void Update () {

		if (padMoveUpTimer > 0)
		{
			padMoveUpTimer -= Time.unscaledDeltaTime;
		}
		if (padMoveDownTimer > 0)
		{
			padMoveDownTimer -= Time.unscaledDeltaTime;
		}
		GetInput();
	}

	protected virtual void GetInput()
	{
		//Select button
		if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetAxisRaw("Vertical") > 0.2f && padMoveUpTimer <= 0))
		{
			UpdateIndex(-1);
			padMoveUpTimer = Constants.constants.gamepadMoveTimer;
			padMoveDownTimer = 0;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetAxisRaw("Vertical") < -0.2f && padMoveDownTimer <= 0))
		{
			UpdateIndex(1);
			padMoveDownTimer = Constants.constants.gamepadMoveTimer;
			padMoveUpTimer = 0;
		}
		if (Mathf.Abs(Input.GetAxisRaw("Vertical")) < 0.2f)
		{
			padMoveUpTimer = 0;
			padMoveDownTimer = 0;
		}

		//Click button
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Grab"))
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
				//buttons[i].GetComponent<Image>().color = Color.green;
				buttonText[i].color = Color.red;
			}
			else
			{
				//buttons[i].GetComponent<Image>().color = Color.white;
				buttonText[i].color = Color.white;
			}
		}
	}

	protected virtual void ClickButton() {}

}
