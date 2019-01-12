using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIV2 : MonoBehaviour {

    public enum AIState {inDistress, Amused, Neutral, Fleeing};

    [Space]
    [Header("READ-ONLY")]
    public List<AttractionCircleV2> AttractionCircleList = new List<AttractionCircleV2>();
    public AIState myState = AIState.Neutral;

    [Space]
    [Header("VariablesToTweak")]
    public float cooldownInDistressValue;

    [Space]
    [Header("Referencies")]
    public Renderer myRenderer;
    public NavMeshAgent myNavMeshAgent;
    public Material redMat;
    public Material whiteMat;
    public Material greenMat;
    public Material yellowMat;


    float cooldownInDistress;
    AttractionCircleV2 currentAttractionCircle;
    AISpots currentSpot;
    AttractionCircleV2 attractionCircleFleeing;



    public void AddAttractionCircle(AttractionCircleV2 _newAttractionCircle)
    {
        AttractionCircleList.Add(_newAttractionCircle);
        CompareAttractionCircles();
    }

    public void RemoveAttractionCircle(AttractionCircleV2 _oldAttractionCircle)
    {
        if(myState == AIState.Fleeing && _oldAttractionCircle == attractionCircleFleeing)
        {
            SetState(AIState.Neutral);
        }
        AttractionCircleList.Remove(_oldAttractionCircle);
        CompareAttractionCircles();
    }

    public void CompareAttractionCircles()
    {
        AttractionCircleV2 _targetedAttractionCircle = null;
        int maxScore = 0;
        for (int i = 0; i < AttractionCircleList.Count; i++)
        {
            if (AttractionCircleList[i].repulse)
            {
                attractionCircleFleeing = AttractionCircleList[i];
                SetState(AIState.Fleeing);
                print("flee!!");
                return;
            }
            if (AttractionCircleList[i].score > maxScore)
            {
                _targetedAttractionCircle = AttractionCircleList[i];
                maxScore = _targetedAttractionCircle.score;
            }
        }
        if (maxScore > 0 && _targetedAttractionCircle!=null)
        {
            SetNewCurrentAttractionCircle(_targetedAttractionCircle);
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
            for (int i = 0; i < currentAttractionCircle.mySpots.Length; i++)
            {
                if (currentAttractionCircle.mySpots[i].availability)
                {
                    if (currentSpot != null)
                    {
                        currentSpot.availability = true;
                    }
                    currentSpot = currentAttractionCircle.mySpots[i];
                    currentSpot.availability = false;
                    return;
                }
            }

        }
    }

    void GoToCurrentSpot()
    {
        if ((myState == AIState.Neutral || myState == AIState.Amused) && currentSpot!= null)
        {
            myNavMeshAgent.SetDestination(currentSpot.transform.position);
            SetState(AIState.Neutral);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetState(AIState.inDistress);
        }

        switch (myState)
        {
            case AIState.inDistress:
                cooldownInDistress -= Time.deltaTime;
                if (cooldownInDistress <= 0)
                {
                    SetState(AIState.Neutral);
                }
                break;
            case AIState.Amused:
                break;
            case AIState.Neutral:
                if(currentSpot != null && myNavMeshAgent.remainingDistance < 0.5f)
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
        switch (_newState)
        {
            case AIState.inDistress:
                myState = AIState.inDistress;
                cooldownInDistress = cooldownInDistressValue;
                myRenderer.material = redMat;
                ResetAttractionCirclesAndSpots();
                myNavMeshAgent.SetDestination(transform.position);
                break;
            case AIState.Amused:
                myState = AIState.Amused;
                myRenderer.material = greenMat;
                break;
            case AIState.Neutral:
                myState = AIState.Neutral;
                myRenderer.material = whiteMat;
                break;
            case AIState.Fleeing:
                myState = AIState.Fleeing;
                myRenderer.material = yellowMat;
                ResetAttractionCirclesAndSpots();
                Vector3 newDestination = (transform.position - attractionCircleFleeing.transform.position).normalized * (attractionCircleFleeing.GetComponent<SphereCollider>().radius+1);
                myNavMeshAgent.SetDestination(newDestination);
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
        currentSpot = null;
    }
}
