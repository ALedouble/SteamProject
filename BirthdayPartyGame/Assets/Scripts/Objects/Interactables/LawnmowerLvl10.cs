using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnmowerLvl10 : Interactable
{

    [Space]
    public AudioSource myAudioSource;
    public Animator anim;
    [Space]
    public float speed = 2;
    public float maxSpeed = 30;
    public float gravityAdded = 3;
    [Space]
    public GameObject explosionParticlePrefab;
    public GameObject smokeParticlePrefab;
    public Transform explosionTransform;

    public float damageZoneHeight = .3f;
    public float pushAwayForce = 80;
    public bool isAnimated;
    bool hasJumped;

    public override void Activate()
    {
        base.Activate();
        transform.parent = null;
        if (!canActivate) return;
        if (isAnimated && !hasJumped)
        {
            print("Activated");
            anim.SetTrigger("Jump");
            hasJumped = true;
        }
        else
        {
            activated = true;
        }
        canBreak = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        activated = false;
        canBreak = false;
    }

    private void FixedUpdate()
    {
        if (activated /*&& (Mathf.Abs(body.velocity.y) < 1)*/)
        {
            body.mass = 50;
            //body.velocity = self.forward * maxSpeed;
            body.AddForce(self.forward * speed, ForceMode.Acceleration);
            body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
            if (Mathf.Abs(body.velocity.y) > 1)
            {
                WaitToDeactivate();
            }
        }
        if (Mathf.Abs(body.velocity.y) > 1)
        {
            body.AddForce(Vector3.down * gravityAdded, ForceMode.Acceleration);
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
        if (activated)
        {
            if (collision.collider.tag == "Player")
            {
                PlayerController _player = collision.collider.GetComponent<PlayerController>();
                Vector3 _directionToPlayer = _player.self.position - self.position;
                int _lateralDirection = 0;
                if (Vector3.SignedAngle(self.forward, _directionToPlayer, Vector3.up) > 0)
                {
                    _lateralDirection = 1;
                }
                else
                {
                    _lateralDirection = -1;
                }
                Vector3 _direction = self.right * _lateralDirection;
                _player.body.AddForce(_direction * pushAwayForce, ForceMode.VelocityChange);
            }
            else if (collision.contacts[0].point.x >= self.position.x + damageZoneHeight &&
                    (collision.collider.GetComponent<ObjectParameters>() == null || !collision.collider.GetComponent<ObjectParameters>().destructible))
            {
                StartCoroutine(WaitToDeactivate());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            print("zzz");
            Die();
        }
    }

    IEnumerator WaitToDeactivate()
    {
        yield return new WaitForSeconds(.5f);
        Deactivate();
    }

}