using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSphereEvents : MonoBehaviour {

    public GameObject burstExplosionSphereSide1;
    public GameObject burstExplosionSphereSide2;
    public GameObject burstExplosionSphereSide3;
    GameObject burstExplosionSphereSide1Ref;
    GameObject burstExplosionSphereSide2Ref;
    GameObject burstExplosionSphereSide3Ref;

    public void InstantiateSide3()
    {
        burstExplosionSphereSide3Ref = Instantiate(burstExplosionSphereSide3, transform.position, Quaternion.identity);
        Destroy(burstExplosionSphereSide3Ref, 1);
    }

    public void InstantiateSide1And2()
    {
        burstExplosionSphereSide1Ref = Instantiate(burstExplosionSphereSide1, transform.position, Quaternion.identity);
        burstExplosionSphereSide2Ref = Instantiate(burstExplosionSphereSide2, transform.position, Quaternion.identity);
    }
    public void DestroyMyself()
    {
        Destroy(burstExplosionSphereSide1Ref, 1);
        Destroy(burstExplosionSphereSide2Ref, 4);
        Destroy(gameObject);
    }
}
