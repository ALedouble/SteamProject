using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LD8Cake : Interactable {

    public ObjectParameters[] candlesParam;
    public Rigidbody[] candlesRB;

    public override void Die()
    {
        for (int i = 0; i < candlesParam.Length; i++)
        {
            candlesParam[i].pickUp = true;
            candlesRB[i].isKinematic = false;
            candlesRB[i].transform.parent = null;
        }
    }
}
