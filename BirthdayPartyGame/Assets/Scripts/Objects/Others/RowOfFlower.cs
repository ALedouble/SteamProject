using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowOfFlower : MonoBehaviour {

    public int nbFlower;
    public AttractionCircleV2 myAttractionCircle;

    public void ActualizeNbFlower()
    {
        nbFlower--;
        if (nbFlower <= 0)
        {
            myAttractionCircle.ChangeScore(0);
            Destroy(gameObject);
        }
    }
}
