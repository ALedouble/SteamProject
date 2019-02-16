using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenLight : Interactable {

    public override void Die()
    {
        if (!electrified)
        {
            GetElectrified(null);
            electricityScript.canSpread = true;
            electricityScript.firstGeneration = true;
        }
        //base.Die();
    }

}
