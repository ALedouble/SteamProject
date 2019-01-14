using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Interactable {

    public AttractionCircleV2 myAttractionCircle;
	public float shootForce;
    public int minScore;
    public int maxScore;
    public float timeBeingAtMaxScore;
    float cooldownBeforeMinScore;

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
    }

}
