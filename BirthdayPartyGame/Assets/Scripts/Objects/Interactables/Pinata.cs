using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinata : Interactable
{

    LineRenderer line;
    SpringJoint joint;

    [Space]
    [Header("Variables to tweak")]
    public GameObject containedObject;
    public bool linked;
    public int scoreOnceDestroyed;


    [Space]
    [Header("Referencies")]
    public GameObject confettiParticlesPrefab;
    public AudioSource myAudioSource;
    public AudioClip dieAudioClip;
    public AttractionCircleV2 myAttractionCircle;

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
		//base.Die();
		if (dead) return;
		if (DieEvent != null)
			DieEvent(this);
		dead = true;
        if(myAttractionCircle != null)
        {
            myAttractionCircle.ChangeScore(scoreOnceDestroyed);
        }
        GameObject _confettiParticlesRef = Instantiate(confettiParticlesPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(_confettiParticlesRef, 2.5f);
        print("beforePlay");
        myAudioSource.PlayOneShot(dieAudioClip);
        print("afterPlay");
       
        if (containedObject != null)
		{
            Rigidbody newObjectBody = Instantiate(containedObject, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
			if (newObjectBody != null)
			{
				newObjectBody.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
			}
		}
		Destroy(gameObject);
	}

    private void OnJointBreak(float breakForce)
    {
        line.positionCount = 0;
        line.enabled = true;
    }

}
