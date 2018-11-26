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

	public Animator anim2;

	bool sad = false;
	bool amused = false;
	public GameObject tears;


	


	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("sad", sad);

		anim2.SetBool("sad", sad);
		anim2.SetBool("amused", amused);
		anim2.SetFloat("MoveSpeed", agent.speed);
		
		if (sad){
			tears.SetActive(true);
		}

		if (Input.GetKeyDown(KeyCode.B)){
			sad = true;
		}

		if (anim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Amused")){
			amused = true;
		}

		
		
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "P_Bat"){
			sad = true;
		}
	}
}
