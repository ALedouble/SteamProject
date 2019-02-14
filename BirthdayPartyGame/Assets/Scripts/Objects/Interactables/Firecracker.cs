using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firecracker : Interactable {

	bool chargingExplosion;
	public float explosionCooldown = 3;
	float explosionTimer;
    bool explosionDone;

	public GameObject explosion;
	public float explosionSize = 2.5f;

    public AudioSource myAudioSource;
    public AudioClip explosionClip;
    
    void Update () {
		if (burning && !chargingExplosion && !explosionDone)
		{
			chargingExplosion = true;
            myAudioSource.Play();
		}
		else if (!burning && chargingExplosion && !explosionDone)
		{
			chargingExplosion = false;
			explosionTimer = 0;
            if(myAudioSource.loop)
                myAudioSource.Stop();
        }

		if (chargingExplosion)
		{
			if (explosionTimer < explosionCooldown)
			{
				explosionTimer += Time.deltaTime;
			}
			else if(!explosionDone)
			{
                explosionDone = true;
                Explode();
                Invoke("Die", explosionClip.length);
			}
		}
	}

	public override void Die()
	{
		base.Die();
	}

	void Explode()
	{
        Explosion newExplosion = Instantiate(explosion, self.position, Quaternion.identity).GetComponent<Explosion>();
		newExplosion.InitializeScale(explosionSize);
        if (myAudioSource.loop)
            myAudioSource.Stop();
        myAudioSource.loop = false;
        myAudioSource.clip = null;
        myAudioSource.PlayOneShot(explosionClip);
        //Die();
    }
}
