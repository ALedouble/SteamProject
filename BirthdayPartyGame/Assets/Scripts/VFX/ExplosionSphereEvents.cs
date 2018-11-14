using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSphereEvents : MonoBehaviour {

    public GameObject burstExplosionSphereSide1;
    public GameObject burstExplosionSphereSide2;
    GameObject burstExplosionSphereSide1Ref;
    GameObject burstExplosionSphereSide2Ref;


    public void InstantiateParticles()
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
