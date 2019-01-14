using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSwitcher : Interactable {

    public Animator bridgeBarrierAnim;
    public bool opened;

    protected override void Start()
    {
        base.Start();
    }

    public override void Activate()
    {
        base.Activate();
        if (!activated)
        {
            activated = true;
            bridgeBarrierAnim.SetTrigger("ToggleTrigger");
            opened = true;
        }
        else
        {
            Deactivate();
            activated = false;
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();
        bridgeBarrierAnim.SetTrigger("ToggleTrigger");
        opened = false;
    }
}
