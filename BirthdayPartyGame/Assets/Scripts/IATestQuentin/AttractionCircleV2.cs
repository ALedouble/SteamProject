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
    float oldRadius;
    [HideInInspector]
    public float wantedRadius;
    float lerpValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            print("Ai Trigger In");
            other.GetComponent<AIV2>().AddAttractionCircle(this);
            AIsInRange.Add(other.GetComponent<AIV2>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AI")
        {
            print("Ai Trigger Out");
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
        oldRadius = mySphereCollider.radius;
        wantedRadius = _newRadius;
        lerpValue = 0;
        StopAllCoroutines();
        StartCoroutine(ChangeRadiusCoroutine());
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

    IEnumerator ChangeRadiusCoroutine()
    {
        mySphereCollider.radius = Mathf.Lerp(oldRadius, wantedRadius, lerpValue);
        yield return new WaitForSeconds(0.03f);
        lerpValue = Mathf.Clamp01(lerpValue+0.06f);
        if (lerpValue < 1)
        {
            StartCoroutine(ChangeRadiusCoroutine());
        }
        else
        {
            Invoke("Hey", 0.2f);
        }
    }

    void Hey()
    {
        transform.position += transform.up * 0.01f;
    }
}
