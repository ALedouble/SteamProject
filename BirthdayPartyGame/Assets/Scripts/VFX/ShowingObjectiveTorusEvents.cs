using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowingObjectiveTorusEvents : MonoBehaviour {

	public void DestroyMyself()
    {
        Destroy(transform.parent.gameObject);
    }
}
