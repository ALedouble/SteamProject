using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionCircleV2 : MonoBehaviour {

    [Space]
    [Header("Referencies")]
    public SphereCollider mySphereCollider;

    [Space]
    [Header("Values to Tweak")]
    public int score;
    public AISpots[] mySpots;

    [HideInInspector]
    public bool repulse;
    Vector3 latestPosition;
    List<AIV2> AIsInRange = new List<AIV2>();

    private void OnTriggerEnter(Collider other)
    {
        print("hey");
        if (other.tag == "AI")
        {
            print("hoy");
            other.GetComponent<AIV2>().AddAttractionCircle(this);
            AIsInRange.Add(other.GetComponent<AIV2>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AI")
        {
            other.GetComponent<AIV2>().RemoveAttractionCircle(this);
            AIsInRange.Remove(other.GetComponent<AIV2>());
        }
    }
    
    public void ChangeScore(int _newScore)
    {
        score = _newScore;
        for (int i = 0; i < AIsInRange.Count; i++)
        {
            AIsInRange[i].CompareAttractionCircles();
        }
    }

    public void ChangeRepulse(bool _doesItRepulse)
    {
        repulse = _doesItRepulse;
        for (int i = 0; i < AIsInRange.Count; i++)
        {
            AIsInRange[i].CompareAttractionCircles();
        }
    }

    public void ChangeRadius(float _newRadius)
    {
        mySphereCollider.radius = _newRadius;
    }

    private void Update()
    {
        if(transform.position != latestPosition)
        {
            for (int i = 0; i < AIsInRange.Count; i++)
            {
                AIsInRange[i].CompareAttractionCircles();
            }
        }
        latestPosition = transform.position;
    }
}
