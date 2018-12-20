﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSwitcher : Interactable {

    public Animator bridgeBarrierAnim;

    protected override void Start()
    {
        base.Start();
    }

    public override void Activate()
    {
        base.Activate();
        if (!activated)
        {
            bridgeBarrierAnim.SetTrigger("ToggleTrigger");
        }
        else
        {
            Deactivate();
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();
        bridgeBarrierAnim.SetTrigger("ToggleTrigger");
    }
}
