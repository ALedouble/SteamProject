using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTheWayScript : NPCBaseFSM {

	Animator anim;
	CircleAttraction[] ca;	
	ChildAI[] child;
	float IdleTime = 0;
	public float animDistance;
	public float cooldown;
	int maxValue;
	int maxValueGlobal;
	public bool inCircle;
	

	

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
			float distance = Vector3.Distance(agent.transform.position, ca[i].transform.position); // Check la distance entre l'IA est les cercles d'attractions.
			
			Debug.Log(maxValue);

			if(ca[i].valueCircle > maxValue) // Change la valeur du cercle d'attraction en cas de valeur plus grande
			{
				maxValue = ca[i].valueCircle;
			}

			if (ca[i].repulse == false){
				if (ca[i].valueCircle == maxValue && ca[i].repulse == false) // Quand la valeur est la plus grande et que l'ia s'est donc dirigé vers le cercle avec la plus grande valeur
				{
					if (distance <= ca[i].radius) // Si l'IA est dans un cercle d'attraction alors : 
					{
						Debug.Log(maxValue);
						inCircle = true; // Active un booléen 
						cooldown = 0;

						float distanceClosestPoint = Mathf.Infinity; 

						for(int y = 0; y < ca[i].allPOI.Length; y++){ // Check tout les POI du cercle d'attraction
							float distanceToPOI = Vector3.Distance(agent.transform.position, ca[i].allPOI[y].transform.position); // Check distance entre IA et les POI

							if (distanceToPOI < distanceClosestPoint) // Si la distance est plus petite alors l'IA se dirige vers ce POI
							{
								distanceClosestPoint = distanceToPOI;
								agent.SetDestination(ca[i].allPOI[y].transform.position);
								Debug.DrawLine(NPC.transform.position, ca[i].allPOI[y].transform.position);

								animDistance = Vector3.Distance(NPC.transform.position, ca[i].allPOI[y].transform.position);
								anim.SetFloat("distance", Vector3.Distance(NPC.transform.position, ca[i].allPOI[y].transform.position));
							}
						} 	
					}
				}
				else if (distance >  ca[i].radius) // Si l'ia n'est pas dans un cercle d'attraction
				{
					Debug.Log("hey wtf");
					inCircle = false;
					cooldown -= Time.deltaTime; //Diminue le cooldown
					agent.speed = 0;

					if (cooldown <= 0){ // Quand le cooldowon est à 0
						agent.speed = 3.5f;
						Debug.Log("oui");
						cooldown = 0;

						Debug.Log(maxValue);
						

						if (inCircle == false){
							for (int z = 0; z < ca.Length; z++){
								if(ca[z].valueCircle > maxValueGlobal) // Change la valeur du cercle d'attraction en cas de valeur plus grande
								{
									maxValueGlobal = ca[z].valueCircle;
								}


								if (ca[z].valueCircle == maxValueGlobal) // Quand la valeur est la plus grande et que l'ia s'est donc dirigé vers le cercle avec la plus grande valeur
								{
									agent.SetDestination(ca[z].transform.position);
								}
							}
						}
										
					}
				}
			}
			else if (ca[i].repulse == true){
				ScriptPOI closestPOI = null;
				ScriptPOI[] globalPOI = GameObject.FindObjectsOfType<ScriptPOI>();

				
				
				for (int y = 0; y < globalPOI.Length; y++)
				{
					float distanceRepulse = Vector3.Distance(ca[i].transform.position, globalPOI[y].transform.position);
					

					if (distanceRepulse <= ca[i].radius){
						agent.SetDestination(globalPOI[y].transform.position);
						Debug.DrawLine(NPC.transform.position, globalPOI[y].transform.position);
					}

					

				}
			}		
		}
	}
}	



	
