using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayWaterMachine : MonoBehaviour {

    public GameObject waterSpherePrefab;
    public Transform spawnPoint;
    
	void Start () {
        StartCoroutine(SprayWater());
	}

    IEnumerator SprayWater()
    {
        GameObject gameObjectRef = Instantiate(waterSpherePrefab, spawnPoint.position, spawnPoint.rotation);
        gameObjectRef.GetComponent<Rigidbody>().AddForce(500 * spawnPoint.forward + 100 * spawnPoint.up);
        Destroy(gameObjectRef, 1f);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(SprayWater());
    }
}
