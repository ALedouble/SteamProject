using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {

    public AttractionCircleV2 myAttractionCircle;
    public Renderer myRenderer;
    public int minScore;
    public int maxScore;

    protected override void Start()
    {
        base.Start();
    }

    public override void Activate()
    {
        base.Activate();
        if (!activated)
        {
            myAttractionCircle.ChangeScore(maxScore);
            myRenderer.material.color = Color.yellow;
            activated = true;
        }
        else
        {
            Deactivate();
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();
        myAttractionCircle.ChangeScore(minScore);
        myRenderer.material.color = Color.white;
        activated = false;
    }
}
