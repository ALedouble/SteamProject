using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {

    public CircleAttraction myCircleAttraction;
    public Renderer myRenderer;

    protected override void Start()
    {
        base.Start();
    }

    public override void Activate()
    {
        base.Activate();
        if (!activated)
        {
            myCircleAttraction.valueCircle = 20;
            myRenderer.material.color = Color.yellow;
            activated = true;
        }
        else
        {
            print("prout");
            Deactivate();
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();
        myCircleAttraction.valueCircle = 0;
        myRenderer.material.color = Color.white;
        activated = false;
    }
}
