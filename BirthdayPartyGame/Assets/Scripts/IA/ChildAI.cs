using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAI : MonoBehaviour {
	public GameObject player;
	public GameObject GetPlayer()
	{
		return player;
	}

 	UnityEngine.AI.NavMeshAgent agent;

	Animator anim;

	bool sad;

	


	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("sad", sad);

		if (Input.GetKeyDown(KeyCode.B)){
			sad = true;
		}
	}
}
