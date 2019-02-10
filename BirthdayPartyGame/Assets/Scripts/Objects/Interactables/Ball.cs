using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Interactable, ILaunchable {

    public AttractionCircleV2 myAttractionCircle;
	public float shootForce;
    public int minScore;
    public int maxScore;
    public float timeBeingAtMaxScore;
    float cooldownBeforeMinScore;
	public float canBreakThreshold = 2;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player")
		{
			GetShot(collision.contacts[0].point, collision.rigidbody.velocity);
		}
	}

	void GetShot(Vector3 _impactPoint, Vector3 otherSpeed)
	{
		Vector3 direction = self.position - _impactPoint;
		body.AddForce(direction.normalized * shootForce + otherSpeed/2, ForceMode.VelocityChange);
        myAttractionCircle.ChangeScore(maxScore);
        cooldownBeforeMinScore = timeBeingAtMaxScore;
	}

	public void GetLaunched(Vector3 _direction, float _force)
	{
		body.AddForce(_direction * _force, ForceMode.VelocityChange);
	}

	public override void GetDropped()
	{
		GetLaunched(self.right, 20);
		base.GetDropped();
	}

	private void Update()
    {
        if (cooldownBeforeMinScore > 0)
        {
            cooldownBeforeMinScore -= Time.deltaTime;
            if (cooldownBeforeMinScore <= 0)
            {
                myAttractionCircle.ChangeScore(minScore);
            }
        }

		if (body.velocity.magnitude > canBreakThreshold)
		{
			canBreak = true;
			print("Can break");
		}
		else
		{
			canBreak = false;
		}
    }

}
