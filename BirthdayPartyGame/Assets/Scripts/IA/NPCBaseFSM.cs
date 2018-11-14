using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour {

	public GameObject NPC;
	public GameObject player;

	public Rigidbody rb;

	public UnityEngine.AI.NavMeshAgent agent;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
		NPC = animator.gameObject;
		player = NPC.GetComponent<ChildAI>().GetPlayer();
		agent = NPC.GetComponent<UnityEngine.AI.NavMeshAgent>();
		rb = NPC.GetComponent<Rigidbody>();
	}
}
