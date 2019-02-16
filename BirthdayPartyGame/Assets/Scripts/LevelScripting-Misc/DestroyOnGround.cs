using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGround : MonoBehaviour {

	public List<GameObject> destroyedBy;

    bool dead;

    private void OnCollisionEnter(Collision other)
    {
        if((other.collider.tag == "Ground" || destroyedBy.Contains(other.gameObject)) && !dead) {
            GetComponent<Breakable>().Break(other.contacts[0].point);
            dead = true;
        }
    }
}
