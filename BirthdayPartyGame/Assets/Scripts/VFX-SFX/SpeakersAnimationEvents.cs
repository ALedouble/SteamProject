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
        Destroy(Instantiate(popParticlePrefab, particleSpawnPos.position, particleSpawnPos.rotation, particleSpawnPos), 2f);
    }

    public void SpawnHardParticlePrefab()
    {
        Destroy(Instantiate(hardParticlePrefab, particleSpawnPos.position, particleSpawnPos.rotation, particleSpawnPos), 2f);
    }
}
