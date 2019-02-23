using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : PanelUI {

	public Text[] objectivesText;
	public Image[] objectiveIcon;
	public Text[] subObjectivesText;
	public Image[] subObjectiveIcon;
	public Text timeText;
	public Text scoreText;
	public GameObject clock;


	protected override void Start()
	{
		base.Start();
		if (GameManager.instance.mode == LevelsMode.Default)
		{
			Initialize();
		}
		else
		{
			InitializeDestruction();
		}
	}

	void Initialize()
	{

		int progression = SaveManager.instance.currentSave.progressionIndex;
		SaveManager.Save.Level level = SaveManager.instance.currentSave.levels[SaveManager.instance.currentSave.lastLevelIndex-1];

		for (int i = 0; i < objectivesText.Length; i++)
		{
			if (i < level.objectiveNames.Length)
			{
				objectiveIcon[i].enabled = true;
				//if (level.id < progression)
				//{
					objectiveIcon[i].sprite = Constants.constants.checkedIcon;
				//}
				//else
				//{
				//	objectiveIcon[i].sprite = Constants.constants.emptyIcon;
				//}
				//for (int x = 0; x < _objectivesText.Length; x++)
				//{
				objectivesText[i].text = level.objectiveNames[i];
				//}
			}
			else
			{
				objectivesText[i].text = "";
				objectiveIcon[i].enabled = false;
			}
		}
		for (int i = 0; i < subObjectivesText.Length; i++)
		{
			if (i < level.subObjectiveNames.Length)
			{
				subObjectiveIcon[i].enabled = true;
				if (level.completedSecondaryObjectives[i])
				{
					subObjectiveIcon[i].sprite = Constants.constants.checkedIcon;
				}
				else
				{
					subObjectiveIcon[i].sprite = Constants.constants.emptyIcon;
				}
				//for (int x = 0; x < _subObjectivesText.Length; x++)
				//{
				subObjectivesText[i].text = level.subObjectiveNames[i];
				//}
			}
			else
			{
				subObjectivesText[i].text = "";
				subObjectiveIcon[i].enabled = false;
			}
		}
		timeText.text = SaveManager.instance.currentSave.lastLevelTime.ToString("#.##");
		scoreText.text = "";
	}

	void InitializeDestruction()
	{
		int progression = SaveManager.instance.currentSave.progressionIndex;
		SaveManager.Save.Level level = SaveManager.instance.currentSave.levels[SaveManager.instance.currentSave.lastLevelIndex];

		for (int i = 0; i < objectivesText.Length; i++)
		{
			objectiveIcon[i].enabled = false;
			objectivesText[i].text = "";
		}
		for (int i = 0; i < subObjectivesText.Length; i++)
		{
			subObjectiveIcon[i].enabled = false;
			subObjectivesText[i].text = "";
		}
		timeText.text = "";
		scoreText.text = SaveManager.instance.currentSave.lastScore.ToString("#.##");
		clock.SetActive(false);
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
				Utility.LevelSelection();
				break;

			case 3:
				Utility.Menu();
				break;
		}
	}

}
