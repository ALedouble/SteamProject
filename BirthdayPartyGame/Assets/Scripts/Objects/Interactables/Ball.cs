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
    public TrailRenderer myTrailRenderer;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player")
		{
			GetShot(collision.contacts[0].point, collision.rigidbody.velocity);
		}
		//if(collision.collider.GetComponent<Interactable>() != null)
		//{
		//	Interactable other = collision.collider.GetComponent<Interactable>();
		//	if (other.parameters.breakable && canBreak)
		//	{
		//		print("Should break");
		//	}
		//}
		if (canBreak)
		{
			canBreak = false;
		}
	}

	public void ShootToBreak()
	{
		canBreak = true;
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

		//if (body.velocity.magnitude > canBreakThreshold)
		//{
		//	canBreak = true;
  //          /*if(!myTrailRenderer.enabled)
  //              myTrailRenderer.enabled = true;*/

  //          print("Can break");
		//}
		//else
		//{
		//	canBreak = false;
  //          /*if (myTrailRenderer.enabled)
  //              myTrailRenderer.enabled = false;*/
  //      }
    }

}
