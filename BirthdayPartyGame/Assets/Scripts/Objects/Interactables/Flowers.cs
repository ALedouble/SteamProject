using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : Interactable {

    RowOfFlower myParent;


    protected override void Start()
    {
        base.Start();
        myParent = GetComponentInParent<RowOfFlower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerFeet")
        {
            myParent.ActualizeNbFlower();
            Die();
        }
    }
}
