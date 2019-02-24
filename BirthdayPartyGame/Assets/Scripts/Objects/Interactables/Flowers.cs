using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : Interactable
{

    RowOfFlower myParent;
    public AudioSource myAudioSource;
    public AudioClip destroyClip;

    protected override void Start()
    {
        base.Start();
        myParent = GetComponentInParent<RowOfFlower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerFeet")
        {
            myAudioSource.PlayOneShot(destroyClip);
            Die();
        }
    }

    public override void Die()
    {
        myParent.ActualizeNbFlower();
        base.Die();
    }
}
