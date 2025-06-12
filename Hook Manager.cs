using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooking : MonoBehaviour
{
    public GameObject Hook;

    void OnTriggerEnter(Collider other)
    {

            Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
            if (otherRigidbody != null)
            {
                otherRigidbody.constraints = RigidbodyConstraints.FreezeAll;

            }
 
    }

    void OnTriggerExit(Collider other)
    {

            Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
            if (otherRigidbody != null)
            {
                otherRigidbody.useGravity = true;
                otherRigidbody.constraints = RigidbodyConstraints.None;
            }

    }
}


