using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinata : Interactable {

    LineRenderer line;
    SpringJoint joint;

    public GameObject containedObject;
    public bool linked;

    private void Start()
    {
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
