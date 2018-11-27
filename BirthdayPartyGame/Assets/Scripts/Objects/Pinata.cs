using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinata : Interactable
{

    LineRenderer line;
    SpringJoint joint;

    public GameObject containedObject;
    public bool linked;

    public GameObject confettiParticlesPrefab;

    public AudioSource myAudioSource;
    public AudioClip dieAudioClip;
    public CircleAttraction ca;

    protected override void Start()
    {
		base.Start();
        if (linked)
        {
            line = GetComponent<LineRenderer>();
            joint = GetComponent<SpringJoint>();
            line.positionCount = 2;
        }
    }

    private void Update()
    {
        if (linked)
        {
            line.SetPosition(0, self.TransformPoint(joint.anchor));
            line.SetPosition(1, joint.connectedBody.position + joint.connectedAnchor);
        }
    }

    public override void Die()
    {
        ca.valueCircle = 10;
        GameObject _confettiParticlesRef = Instantiate(confettiParticlesPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(_confettiParticlesRef, 2.5f);
        print("beforePlay");
        myAudioSource.PlayOneShot(dieAudioClip);
        print("afterPlay");
        base.Die();
        if (containedObject != null)
            Instantiate(containedObject, transform.position, Quaternion.identity);
    }

    private void OnJointBreak(float breakForce)
    {
        line.positionCount = 0;
        line.enabled = true;
    }

}
