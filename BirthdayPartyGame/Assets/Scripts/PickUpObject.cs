using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    Vector3 objectPos;
    float distance;

    [Space]
    [Header ("Components")]
    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public GameObject pickUp; 
    public bool isHolding = false;

    [Space]
    [Header ("Force")]
    public float throwForce = 900f;


    // Use this for initialization
    void Start () {
		item = gameObject;
		tempParent = GameObject.FindGameObjectWithTag("Player");
        if (tempParent != null)
        {
            pickUp = tempParent.transform.GetChild(tempParent.transform.childCount - 1).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {

        isGrab();
        if (tempParent != null){
            distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
            if (distance >= 3)
            {
                isHolding = false;
            }

            if (isHolding == true)
            {
                item.transform.position = pickUp.transform.position;
                item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                item.transform.SetParent(tempParent.transform);

                if (Input.GetMouseButtonDown(1))
                {
                    item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                    isHolding = false;
                }
            }
            else
            {
                objectPos = item.transform.position;
                item.transform.SetParent(null);
                item.GetComponent<Rigidbody>().useGravity = true;
                item.transform.position = objectPos;
            }
        }
	}

    void isGrab()
    {
        if (Input.GetKeyDown(KeyCode.E) && isHolding == false)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isHolding == true)
        {
            isHolding = false;
        }
    }
}
