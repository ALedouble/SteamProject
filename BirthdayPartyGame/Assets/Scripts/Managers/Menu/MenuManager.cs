using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	int choose = 0;
	public GameObject[] allElements;


	MeshRenderer[] meshTextRed;

	MeshRenderer[] meshTextWhite;

	MeshRenderer[] meshTextWhite2;
	MeshRenderer[] meshTextWhite3;
	MeshRenderer[] meshTextWhite4;
 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			choose += 1;

			
			if (choose > 3){
				choose = 0;
			}
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)){
			choose -= 1;

			if (choose < 0){
				choose = 3;
			}
		}

		 meshTextRed = allElements[choose].GetComponentsInChildren<MeshRenderer>();

		foreach(MeshRenderer colorful in meshTextRed){
			colorful.material.color = Color.red;
		}
		
		
			if (choose < 3){
				meshTextWhite = allElements[choose + 1].GetComponentsInChildren<MeshRenderer>();
				foreach(MeshRenderer colorful in meshTextWhite){
					colorful.material.color = Color.white;
				}
			}
			
			if (choose > 0){
				meshTextWhite2 = allElements[choose - 1].GetComponentsInChildren<MeshRenderer>();
				foreach(MeshRenderer colorful in meshTextWhite2){
					colorful.material.color = Color.white;
				}
			}

			if (choose == 0){
				meshTextWhite3 = allElements[choose + 3].GetComponentsInChildren<MeshRenderer>();
				foreach(MeshRenderer colorful in meshTextWhite3){
					colorful.material.color = Color.white;
				}
			}

			if (choose == 3){
				meshTextWhite4 = allElements[choose - 3].GetComponentsInChildren<MeshRenderer>();
				foreach(MeshRenderer colorful in meshTextWhite4){
					colorful.material.color = Color.white;
				}
			}
		
		 	if (Input.GetKeyDown(KeyCode.Return) && choose == 0){
			//StartCoroutine(LoadScene());

			//SceneManager.UnloadSceneAsync("Menu");
			//SceneManager.LoadScene("LevelNecessities", LoadSceneMode.Single);
			SceneManager.LoadScene("VSD", LoadSceneMode.Single);
		}
	}


   /* IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("VerticalSliceScene 1", LoadSceneMode.Single);
    }

    */
}
