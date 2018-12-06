using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTheWayScript : NPCBaseFSM {

	Animator anim;
	CircleAttraction[] ca;	
	ChildAI[] child;
	float IdleTime = 0;
	bool inRadius = false;

	public float animDistance;

	public float cooldown;

	int maxValue;

	int circleNumber;
	

	void Awake() {
		ca = FindObjectsOfType(typeof(CircleAttraction)) as CircleAttraction[];
		child = FindObjectsOfType(typeof(ChildAI)) as ChildAI[];
	}

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo, layerIndex);
		anim = NPC.GetComponent<Animator>();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
		for (int i = 0; i < ca.Length; i++){

			if(ca[i].valueCircle > maxValue){
				maxValue = ca[i].valueCircle;
			}
			
			/* if(ca[i].valueCircle < maxValue){
				maxValue = 0;
			}
			*/
			float dist = Vector3.Distance(agent.transform.position, ca[i].transform.position);

			Debug.Log(inRadius);

			if(dist <= ca[i].radius)  
			{
				inRadius = true;	
			}
			else {
				inRadius = false;
			}

			if (inRadius == true){
				IdleTime += Time.deltaTime;
				MoveToPOI();
				agent.speed = 3.5f;
				circleNumber = i;
				break;
			} else {
				cooldown -= Time.deltaTime;
				agent.speed = 0;

				if (cooldown <= 0){
					MoveToPOI();
					agent.speed = 3.5f;
					cooldown = 0;
					circleNumber = Random.Range(1, 2);
				}

				
			}
			
		}
	}

	public void MoveToPOI(){
		for (int i = 0; i < ca.Length; i++){
			CircleAttraction[] allPOI = GameObject.FindObjectsOfType<CircleAttraction>();
			agent.SetDestination(allPOI[circleNumber].transform.position);

			animDistance = Vector3.Distance(NPC.transform.position, allPOI[circleNumber].transform.position);
			anim.SetFloat("distance", Vector3.Distance(NPC.transform.position, allPOI[circleNumber].transform.position));
		}
		








		/*for (int i = 0; i < ca.Length; i++){
			float distanceClosestPoint = Mathf.Infinity;
			CircleAttraction closestPOI = null;
			CircleAttraction[] allPOI = GameObject.FindObjectsOfType<CircleAttraction>();
			foreach (CircleAttraction currentPoint in allPOI )
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

				Debug.DrawLine(NPC.transform.position, closestPOI.transform.position);
				a
				}
			}		
		}
		*/
	}
	 
}
		
		

		/* 
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
					//Debug.Log(maxValueCircle);
					Debug.DrawLine(NPC.transform.position, circleNumber[i].transform.position);

					
					if (Input.GetKeyDown(KeyCode.E)){
						maxValueCircle = 0;
						ca[i].valueCircle = -10;
					}	
					

					if(dist <= ca[i].radius) {
						MoveToPOI();
					}
				}


				if(dist <= ca[i].radius) {
						MoveToPOI();
				}
			}


			*/
			
		

		//Debug.Log(maxValueCircle);
	 
	
		



	//	for (int i = 0; i < pointsOfInterests.Length; i++){
			/* float distPOI = Vector3.Distance(agent.transform.position, pointsOfInterests[i].transform.position);
			if(distPOI < minDistPOI){
				minDistPOI = distPOI;
				agent.SetDestination(pointsOfInterests[i].transform.position);

				anim.SetFloat("distance", Vector3.Distance(NPC.transform.position, pointsOfInterests[i].transform.position));
			}


			



	//OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}



	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	*/

