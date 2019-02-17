using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayWaterMachine : MonoBehaviour {

    public GameObject waterSpherePrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public AudioSource myAudioSource;
    public AudioClip throwingWaterClip;

    void Start () {
        StartCoroutine(SprayWater());
	}

    IEnumerator SprayWater()
    {
        GameObject gameObjectRef1 = Instantiate(waterSpherePrefab, spawnPoint1.position, spawnPoint1.rotation);
        gameObjectRef1.GetComponent<Rigidbody>().AddForce(4 * spawnPoint1.forward + 1 * Vector3.up);
        Destroy(gameObjectRef1, 1f);
        GameObject gameObjectRef2 = Instantiate(waterSpherePrefab, spawnPoint2.position, spawnPoint2.rotation);
        gameObjectRef2.GetComponent<Rigidbody>().AddForce(4 * spawnPoint2.forward + 1 * Vector3.up);
        Destroy(gameObjectRef2, 1f);
        myAudioSource.PlayOneShot(throwingWaterClip);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(SprayWater());
    }
}
