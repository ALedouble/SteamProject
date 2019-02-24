
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElectrifying : Interactable
{
    public override void Activate()
    {
        if (!activated)
        {
            base.Activate();
            activated = true;
            GetElectrified(null);
            electricityScript.firstGeneration = true;
        }
        else
        {
            Deactivate();
        }
    }
    public override void Deactivate()
    {
        activated = false;
        base.Deactivate();
        StopElectrified();
    }
}
