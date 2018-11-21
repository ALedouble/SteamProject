using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lawnmower : Interactable {

    [Space]
    public AudioSource myAudioSource;
    [Space]
	public float speed = 2;
	public float maxSpeed = 30;
	public float gravityAdded = 3;
    [Space]
    public GameObject explosionParticlePrefab;
    public GameObject smokeParticlePrefab;
    public Transform explosionTransform;

    public override void Activate()
	{
		base.Activate();
		activated = true;
	}

	public override void Deactivate()
	{
		base.Deactivate();
		activated = false;
	}

	private void FixedUpdate()
	{
		if (activated)
		{
			body.AddForce(self.forward * speed, ForceMode.Acceleration);
			body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
			if (Mathf.Abs(body.velocity.y) > 1)
			{
				body.AddForce(Vector3.down * gravityAdded, ForceMode.Acceleration);
			}
		}
	}

    public override void Die()
    {
        Instantiate(explosionParticlePrefab, explosionTransform.position, Quaternion.identity);
        Instantiate(smokeParticlePrefab, explosionTransform.position, Quaternion.Euler(-90, 0, 0), transform);
        canActivate = false;
        myAudioSource.Stop();
    }

    private void OnCollisionEnter(Collision collision)
	{
		if (activated && collision.rigidbody != null && !collision.rigidbody.isKinematic)
		{
			StartCoroutine(WaitToDeactivate());
		}
	}

	IEnumerator WaitToDeactivate()
	{
		yield return new WaitForSeconds(.1f);
		Deactivate();
	}

}
