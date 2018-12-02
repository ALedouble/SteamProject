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

	public Bat swingBat;

    [Space]
    [Header("Ref for the hit event")]
    public Transform spawnPointForSurpriseParticles;
    public GameObject surpriseParticlesPrefab;
    public AudioSource myAudioSource;
    public AudioClip hitAudioClip;


	


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

		if (other.gameObject.tag == "Interactable") {
			Interactable _object = other.gameObject.GetComponent<Interactable>();
			if (_object.canBreak)
            {
                sad = true;
                if (_object.GetComponent<ObjectParameters>().objectName == "Bat")
                {
                    GameObject _surprisePartRef = Instantiate(surpriseParticlesPrefab, spawnPointForSurpriseParticles.position, Quaternion.Euler(-90, 0, 0), spawnPointForSurpriseParticles);
                    Destroy(_surprisePartRef, 2f);
                    myAudioSource.PlayOneShot(hitAudioClip);
                }
			}
		}
	}
}
