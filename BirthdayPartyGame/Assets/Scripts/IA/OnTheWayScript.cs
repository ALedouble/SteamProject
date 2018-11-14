using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTheWayScript : NPCBaseFSM {

	Animator anim;
	GameObject[] circleNumber;
	CircleAttraction[] ca;	
	int maxValueCircle = 0;

	void Awake() {
		circleNumber = GameObject.FindGameObjectsWithTag("CircleAttraction");
		ca = FindObjectsOfType(typeof(CircleAttraction)) as CircleAttraction[];		
	}

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo, layerIndex);
		anim = NPC.GetComponent<Animator>();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
		
		for (int i = 0; i < ca.Length; i++){
			if(ca[i].valueCircle > maxValueCircle){
				maxValueCircle = ca[i].valueCircle;
			}

			if(ca[i].valueCircle < maxValueCircle){
				maxValueCircle = 0;
			}

			

			float dist = Vector3.Distance(agent.transform.position, circleNumber[i].transform.position);
			
			if (ca[i].valueCircle == maxValueCircle){
				if (dist > ca[i].radius && agent.enabled == true)
				{
					agent.SetDestination(circleNumber[i].transform.position);
					Debug.Log(maxValueCircle);
					Debug.DrawLine(NPC.transform.position, circleNumber[i].transform.position);

					
					if (Input.GetKeyDown(KeyCode.E)){
						maxValueCircle = 0;
						ca[i].valueCircle = -10;
					}	
					
					if(dist <= ca[i].radius) {
						MoveToPOI();
					}
				}
			}



			
		}
	}
		//Debug.Log(maxValueCircle);

	public void MoveToPOI(){
			float distanceClosestPoint = Mathf.Infinity;
			ScriptPOI closestPOI = null;
			ScriptPOI[] allPOI = GameObject.FindObjectsOfType<ScriptPOI>();
			foreach (ScriptPOI currentPoint in allPOI)
			{
				float distanceToPOI = (currentPoint.transform.position - NPC.transform.position).sqrMagnitude;
				if (distanceToPOI < distanceClosestPoint)
				{
					distanceClosestPoint = distanceToPOI;
					closestPOI = currentPoint;
					if(agent.enabled == true)
					{
						agent.SetDestination(closestPOI.transform.position);
					}
				anim.SetFloat("distance", Vector3.Distance(NPC.transform.position, closestPOI.transform.position));

				}
			}
		}



	//	for (int i = 0; i < pointsOfInterests.Length; i++){
			/* float distPOI = Vector3.Distance(agent.transform.position, pointsOfInterests[i].transform.position);
			if(distPOI < minDistPOI){
				minDistPOI = distPOI;
				agent.SetDestination(pointsOfInterests[i].transform.position);

				anim.SetFloat("distance", Vector3.Distance(NPC.transform.position, pointsOfInterests[i].transform.position));
			}


			*/



	//OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}



/* 
	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

*/
}
