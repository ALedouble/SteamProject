using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utility : MonoBehaviour {

	public static void Restart()
	{
		print("Restart");
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}

	public static void Menu()
	{
		print("Go to menu");
		Time.timeScale = 1;
		//SceneManager.GetAllScenes();
		//for (int i = 0; i < SceneManager.sceneCount; i++)
		//{
		//	SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));
		//}
		SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
	}

	public static void NextLevel()
	{
		print("Next level");
		Time.timeScale = 1;
		int progression = SaveManager.instance.currentSave.progressionIndex;
		if (progression < SaveManager.instance.currentSave.levels.Length)
		{
			SceneManager.LoadScene(progression + 1, LoadSceneMode.Single);
		}
	}

	public static Vector3 ConvertUI(Vector3 _position)
	{
		return Camera.main.WorldToScreenPoint(_position);
	}

	public static Vector3 AddOffset(Vector3 _position, Vector3 _offset)
	{
		return new Vector3(_position.x + _offset.x, _position.y + _offset.y, _position.z + _offset.z);
	}

}
