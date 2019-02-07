using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {
    
	public Text levelName;
	public Text description;
	public Text time;
	public Image panel;

	public Text objectivesText;
	public Text subObjectivesText;

	public Vector2 self;

    float lerpValue;
    public float timeToPan;
    public RectTransform myRectTransform;
    public AnimationCurve panAnimCurve;

	// Use this for initialization
	void Start () {
		self = GetComponent<RectTransform>().anchoredPosition;
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
        lerpValue = 0;
        StartCoroutine(ChangeLocation(800, 0));
		//anim.SetTrigger("RtoC");
	}
	public void LtoC()
	{
		self.x = -800;
        lerpValue = 0;
        StartCoroutine(ChangeLocation(-800, 0));
        //anim.SetTrigger("LtoC");
	}
	public void CtoR()
    {
        lerpValue = 0;
        StopAllCoroutines();
        StartCoroutine(ChangeLocation(0, 800));
        //anim.SetTrigger("CtoR");
	}
	public void CtoL()
    {
        lerpValue = 0;
        StopAllCoroutines();
        StartCoroutine(ChangeLocation(0, -800));
        //anim.SetTrigger("CtoL");
	}

	public void EndSwitch()
	{
		LevelSelectionManager.instance.EndSwitchLevel();
	}

    IEnumerator ChangeLocation(float from, float to)
    {
        lerpValue = Mathf.Clamp01(lerpValue + Time.deltaTime/ timeToPan);
        self.x = Mathf.Lerp(from, to, panAnimCurve.Evaluate(lerpValue));
        myRectTransform.localPosition = new Vector3(self.x, 0, 0);
        yield return new WaitForSeconds(0);

        if (lerpValue == 1)
        {
            print("hey");
            EndSwitch();
        }
        else
        {
            StartCoroutine(ChangeLocation(from, to));
        }
    }
}
