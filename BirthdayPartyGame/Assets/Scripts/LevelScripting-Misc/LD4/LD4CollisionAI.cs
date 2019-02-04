using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LD4CollisionAI : MonoBehaviour {

    public GameObject mainAIRef;
    int nbWrongAI;
    bool mainAIHere;
    public bool douglasIsolated;

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "AI")
        {
            if(other.gameObject != mainAIRef)
            {
                nbWrongAI++;
            }
            else
            {
                mainAIHere = true;
            }
        }

        CheckCondition();
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "AI")
        {
            if (other.gameObject != mainAIRef)
            {
                nbWrongAI--;
            }
            else
            {
                mainAIHere = false;
            }
        }
        CheckCondition();
        
    }

    void CheckCondition()
    {
        if(nbWrongAI<=0 && mainAIHere)
        {
			douglasIsolated = true;
        }
        else
        {
            douglasIsolated = false;
        }
    }
}
