using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIV2 : MonoBehaviour {

    public enum AIState {inDistress, Amused, Neutral, Fleeing};

    [Space]
    [Header("READ-ONLY")]
    public AISpots currentSpot;
    public List<AttractionCircleV2> AttractionCircleList = new List<AttractionCircleV2>();
    public AIState myState = AIState.Neutral;

    [Space]
    [Header("Variables To Tweak")]
    public float cooldownInDistressValue;

    [Space]
    [Header("Referencies")]
    public Animator myAnim;
    public NavMeshAgent myNavMeshAgent;
    public Transform spawnPointForSurpriseParticles;
    public GameObject surpriseParticlesPrefab;
    public AudioSource myAudioSource;
    public AudioClip hitAudioClip;
    public GameObject tearsParent;


    float cooldownInDistress;
    AttractionCircleV2 currentAttractionCircle;
    AttractionCircleV2 attractionCircleFleeing;



    public void AddAttractionCircle(AttractionCircleV2 _newAttractionCircle)
    {
        AttractionCircleList.Add(_newAttractionCircle);
        CompareAttractionCircles();
    }

    public void RemoveAttractionCircle(AttractionCircleV2 _oldAttractionCircle)
    {
        if(myState == AIState.Fleeing && _oldAttractionCircle == attractionCircleFleeing) //si le cercle dont on vient de sortir était le repulse
        {
            if (myState != AIState.Neutral)
            {
                SetState(AIState.Neutral);
            }
        }
        AttractionCircleList.Remove(_oldAttractionCircle);
        CompareAttractionCircles();
    }

    public void CompareAttractionCircles()
    {
        AttractionCircleV2 _targetedAttractionCircle = null;
        int maxScore = 0;
        if (AttractionCircleList.Count > 0)
        {
            for (int i = 0; i < AttractionCircleList.Count; i++)
            {
                if (AttractionCircleList[i].repulse) // one repulse circle detected !!
                {
                    attractionCircleFleeing = AttractionCircleList[i];
                    if (myState != AIState.Fleeing)
                    {
                        SetState(AIState.Fleeing);
                    }
                    return;
                }
                if (AttractionCircleList[i].score > maxScore) //attraction circle better than previous ones checked
                {
                    _targetedAttractionCircle = AttractionCircleList[i];
                    maxScore = _targetedAttractionCircle.score;
                }
            }
            if (maxScore > 0 && _targetedAttractionCircle != null && myState != AIState.Fleeing) //new attraction circle found
            {
                SetNewCurrentAttractionCircle(_targetedAttractionCircle);
            }
            else if (myState != AIState.Fleeing) //when no attraction circles
            {
                if (myState != AIState.Neutral)
                {
                    SetState(AIState.Neutral);
                }
                SetNewCurrentAttractionCircle(null);
            }
        }            
    }

    void SetNewCurrentAttractionCircle(AttractionCircleV2 _newCurrentAttractionCircle)
    {
        currentAttractionCircle = _newCurrentAttractionCircle;
        SetNewCurrentSpot();
        GoToCurrentSpot();
    }

    void SetNewCurrentSpot()
    {
        if ((myState == AIState.Neutral || myState == AIState.Amused) && currentAttractionCircle != null)
        {
            float distanceMin = Mathf.Infinity;
            AISpots newSpot = null;
            for (int i = 0; i < currentAttractionCircle.mySpots.Length; i++)
            {
                if (currentAttractionCircle.mySpots[i].availability)
                {
                    if(Vector3.Distance(transform.position, currentAttractionCircle.mySpots[i].transform.position) < distanceMin)
                    {
                        distanceMin = Vector3.Distance(transform.position, currentAttractionCircle.mySpots[i].transform.position);
                        newSpot = currentAttractionCircle.mySpots[i];
                    }
                }
            }
            if(currentSpot != null)
            {
                currentSpot.availability = true;           
            }
            if (newSpot != null)
            {
                currentSpot = newSpot;
                currentSpot.availability = false;
            }
        }
        else if(currentSpot!=null)
        {
            currentSpot.availability = true;
            currentSpot = null;
        }
    }

    void GoToCurrentSpot()
    {
        if ((myState == AIState.Neutral || myState == AIState.Amused) && currentSpot!= null)
        {
            myNavMeshAgent.SetDestination(currentSpot.transform.position);
            if(myNavMeshAgent.remainingDistance > 0.5f)
            {
                if (myState != AIState.Neutral)
                {
                    SetState(AIState.Neutral);
                }
            }
        }
    }

    private void Update()
    {
        myAnim.SetFloat("MoveSpeed", myNavMeshAgent.velocity.magnitude);
        switch (myState)
        {
            case AIState.inDistress:
                cooldownInDistress -= Time.deltaTime;
                if (cooldownInDistress <= 0)
                {
                    if (myState != AIState.Neutral)
                    {
                        SetState(AIState.Neutral);
                    }
                    CompareAttractionCircles();
                }
                break;
            case AIState.Amused:
                if(myNavMeshAgent.remainingDistance > 0.5f)
                {
                    if (myState != AIState.Neutral)
                    {
                        SetState(AIState.Neutral);
                    }
                }
                break;
            case AIState.Neutral:
                if(currentSpot != null && myNavMeshAgent.remainingDistance <= 0.5f)
                {
                    SetState(AIState.Amused);
                }
                break;
            case AIState.Fleeing:
                break;
        }
    }

    void SetState(AIState _newState)
    {
        ExitState();
        switch (_newState)
        {
            case AIState.inDistress:
                myState = AIState.inDistress;
                cooldownInDistress = cooldownInDistressValue;
                int inDistressToInt = (int)AIState.inDistress;
                myAnim.SetInteger("EnumState", inDistressToInt);

                GameObject _surprisePartRef = Instantiate(surpriseParticlesPrefab, spawnPointForSurpriseParticles.position, Quaternion.Euler(-90, 0, 0), spawnPointForSurpriseParticles);
                Destroy(_surprisePartRef, 2f);
                myAudioSource.PlayOneShot(hitAudioClip);
                tearsParent.SetActive(true);
                ResetAttractionCirclesAndSpots();
                myNavMeshAgent.SetDestination(transform.position);
                break;
            case AIState.Amused:
                myState = AIState.Amused;
                int AmusedToInt = (int)AIState.Amused;
                myAnim.SetInteger("EnumState", AmusedToInt);
                break;
            case AIState.Neutral:
                myState = AIState.Neutral;
                int NeutralToInt = (int)AIState.Neutral;
                myAnim.SetInteger("EnumState", NeutralToInt);
                break;
            case AIState.Fleeing:
                myState = AIState.Fleeing;
                int FleeingToInt = (int)AIState.Fleeing;
                myAnim.SetInteger("EnumState", FleeingToInt);
                ResetAttractionCirclesAndSpots();
                myNavMeshAgent.speed = 5;

                //Set the fleeing destination
                Vector3 newDestination = (transform.position - attractionCircleFleeing.transform.position).normalized;
                float distance = attractionCircleFleeing.GetComponent<SphereCollider>().radius;
                newDestination *= distance;
                newDestination.y = transform.position.y;
                newDestination += attractionCircleFleeing.transform.position;
                myNavMeshAgent.SetDestination(newDestination);
                break;
        }
    }

    void ExitState()
    {
        switch (myState)
        {
            case AIState.inDistress:
                tearsParent.SetActive(false);
                break;
            case AIState.Amused:
                break;
            case AIState.Neutral:
                break;
            case AIState.Fleeing:
                myNavMeshAgent.speed = 3.5f;
                break;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            Interactable _object = other.gameObject.GetComponent<Interactable>();
            if (_object.canBreak)
            {
                SetState(AIState.inDistress);
            }
        }
    }

    void ResetAttractionCirclesAndSpots()
    {
        currentAttractionCircle = null;
        if(currentSpot!= null)
        {
            currentSpot.availability = true;
            currentSpot = null;
        }
    }
}
