using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoolTrapaulinAnimEvents : MonoBehaviour {

    public NavMeshObstacle myNavMeshObstacle;
    public BoxCollider myCollider;

    public void DisableNav()
    {
        myNavMeshObstacle.enabled = false;
        myCollider.enabled = false;
    }

    public void EnableNav()
    {
        myNavMeshObstacle.enabled = true;
        myCollider.enabled = true;
    }
}
