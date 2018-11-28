using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakersAnimationEvents : MonoBehaviour {

    public GameObject popParticlePrefab;
    public GameObject hardParticlePrefab;
    public Transform particleSpawnPos;

    public void SpawnPopParticlePrefab()
    {
        print("hey");
        Destroy(Instantiate(popParticlePrefab, particleSpawnPos.position, particleSpawnPos.rotation*Quaternion.Euler(90, 0, 0), particleSpawnPos), 2f);
    }

    public void SpawnHardParticlePrefab()
    {
        Destroy(Instantiate(hardParticlePrefab, particleSpawnPos.position + Vector3.up*0.25f, particleSpawnPos.rotation * Quaternion.Euler(90, 0, 0), particleSpawnPos), 2f);
    }
}
