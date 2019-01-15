using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {

	public Animator anim;

	public Text levelName;
	public Text description;
	public Text time;
	public Image panel;

	public Text objectivesText;
	public Text subObjectivesText;

	public Vector2 self;

	// Use this for initialization
	void Start () {
		self = GetComponent<RectTransform>().anchoredPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Initialize(string _name, string _description, string[] _objectivesText, int _index, string[] _subObjectivesText, bool[] _subComplete, float _time, byte index)
	{
		int progression = SaveManager.instance.currentSave.progressionIndex;

		levelName.text = _name;
		description.text = _description;
		time.text = "Time: " + _time.ToString() + " sec";

		//string objString = "";
		objectivesText.text = "";
		if (index < progression)
		{
			objectivesText.color = new Color(0, 150, 0);
		}
		else
		{
			objectivesText.color = new Color(150, 0, 0);
		}
		for (int i = 0; i < _objectivesText.Length; i++)
		{
			objectivesText.text += "- " + _objectivesText[i] + "\n";
		}

		//objectivesText.text = objString;

		subObjectivesText.text = "Optional: \n";
		for (int i = 0; i < _subComplete.Length; i++)
		{
			if (_subComplete[i])
			{
				subObjectivesText.color = new Color(0, 150, 0);
			}
			else
			{
				subObjectivesText.color = new Color(150, 0, 0);
			}
			subObjectivesText.text += "- " + _subObjectivesText[i] + "\n";
		}

		//subObjectivesText.text = objString;

		
		if (index < progression)
		{
			panel.color = new Color(1, 1, 1);
		}
		else if (index == progression)
		{
			panel.color = new Color(.8f, .8f, .8f);
		}
		else
		{
			panel.color = Color.grey;
		}
	}

	public void RtoC()
	{
		self.x = 800;
		anim.SetTrigger("RtoC");
	}
	public void LtoC()
	{
		self.x = -800;
		anim.SetTrigger("LtoC");
	}
	public void CtoR()
	{
		anim.SetTrigger("CtoR");
	}
	public void CtoL()
	{
		anim.SetTrigger("CtoL");
	}

	public void EndSwitch()
	{
		LevelSelectionManager.instance.EndSwitchLevel();
	}
}
