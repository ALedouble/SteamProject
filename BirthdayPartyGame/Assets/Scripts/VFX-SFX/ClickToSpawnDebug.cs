using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSpawnDebug : MonoBehaviour {

    public GameObject prefabToSpawn;
    public float distanceYFromGround;
    public bool toDestroy;
    public float timeToDestroy;
    public Vector3 eulerOffset;
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray _mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            if (Physics.Raycast(_mouseRay, out _hit))
            {
                GameObject stockPrefab = Instantiate(prefabToSpawn, _hit.point + Vector3.up*distanceYFromGround, Quaternion.Euler(eulerOffset));
                if(toDestroy)
                    Destroy(stockPrefab, timeToDestroy);
            }
        }
	}
}
