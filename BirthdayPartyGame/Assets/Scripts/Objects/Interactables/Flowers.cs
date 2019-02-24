using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : Interactable
{

    RowOfFlower myParent;
    public AudioSource myAudioSource;
    public AudioClip destroyClip;
    public GameObject redPetaleParticle;
    public GameObject purplePetaleParticle;
    public bool amIRed;

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
        if (amIRed)
        {
            GameObject petalePartRef = Instantiate(redPetaleParticle, transform.position + Vector3.up * 0.5f, Quaternion.Euler(-90, 0, 0));
            Destroy(petalePartRef, 1);
        }
        else
        {
            GameObject petalePartRef = Instantiate(purplePetaleParticle, transform.position + Vector3.up * 0.5f, Quaternion.Euler(-90, 0, 0));
            Destroy(petalePartRef, 1);
        }
        base.Die();
    }
}
