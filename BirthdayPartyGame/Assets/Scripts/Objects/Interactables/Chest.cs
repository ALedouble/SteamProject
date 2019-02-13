using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {

    public AttractionCircleV2 myAttractionCircle;
    public int minScore;
    public int maxScore;
    public Animator myAnim;
    public ParticleSystem myParticleSystem;

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
            myAnim.SetBool("OpenBool", true);
            myParticleSystem.Play();
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
        myAnim.SetBool("OpenBool", false);
        myParticleSystem.Clear();
        myParticleSystem.Stop();
        activated = false;
    }
}
