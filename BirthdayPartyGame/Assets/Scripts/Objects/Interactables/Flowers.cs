using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : Interactable
{

    RowOfFlower myParent;
    public AudioSource myAudioSource;
    public AudioClip destroyClip;
    public GameObject petaleParticle;

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
        GameObject petalePartRef = Instantiate(petaleParticle, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(petalePartRef, 1);
        base.Die();
    }
}
