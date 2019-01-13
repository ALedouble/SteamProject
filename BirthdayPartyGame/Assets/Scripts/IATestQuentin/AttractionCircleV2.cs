using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionCircleV2 : MonoBehaviour {

    List<AIV2> AIsInRange = new List<AIV2>();
    public int score;
    public AISpots[] mySpots;
    public bool repulse;

    public bool debug;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
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

    void ChangeRepulse(bool _doesItRepulse)
    {
        repulse = _doesItRepulse;
        for (int i = 0; i < AIsInRange.Count; i++)
        {
            AIsInRange[i].CompareAttractionCircles();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && debug)
        {
            if (repulse)
            {
                ChangeRepulse(false);
            }
            else
                ChangeRepulse(true);
        }
    }
}
