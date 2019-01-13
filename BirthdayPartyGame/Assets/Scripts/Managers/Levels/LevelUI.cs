using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {

	public Animator anim;

	public Text levelName;
	public Text description;
	public Text time;

	public Vector2 self;

	// Use this for initialization
	void Start () {
		self = GetComponent<RectTransform>().anchoredPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Initialize(string _name, string _description, float _time)
	{
		levelName.text = _name;
		description.text = _description;
		time.text = "Time: " + _time.ToString() + " sec";
	}

	public void RtoC()
	{
		anim.SetTrigger("RtoC");
	}
	public void LtoC()
	{
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
