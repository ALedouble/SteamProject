using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlaneToTheGround : MonoBehaviour {

    public Transform collisionPlaneTransform;

	void Start () {
        RaycastHit _hit;
        LayerMask _layerToCheck = 1 << LayerMask.NameToLayer("Ground");
        if (Physics.Raycast(collisionPlaneTransform.position, -Vector3.up, out _hit, 20, _layerToCheck))
        {
            print(_hit.point.y);
            collisionPlaneTransform.position = _hit.point;
        }
	}
}
