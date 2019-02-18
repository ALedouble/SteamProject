using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricitySign : MonoBehaviour {

    public Animator emptyAnim;
    public Animator fullAnim;
    public Interactable myInteractable;
    bool playerIn;

    private void Start()
    {
        emptyAnim.transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - emptyAnim.transform.position);
        fullAnim.transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - fullAnim.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !myInteractable.electrified)
        {
            emptyAnim.SetBool("GrownBool", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !myInteractable.electrified)
        {
            emptyAnim.SetBool("GrownBool", false);
        }
    }

    private void Update()
    {
        if (myInteractable.electrified && !fullAnim.GetBool("GrownBool"))
        {
            fullAnim.SetBool("GrownBool", true);
        }
        else if(!myInteractable.electrified && fullAnim.GetBool("GrownBool"))
        {
            fullAnim.SetBool("GrownBool", false);
        }
    }
}
