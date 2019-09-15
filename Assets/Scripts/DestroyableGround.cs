using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyableGround : MonoBehaviour
{
    public UnityEvent OnFalling;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Boule")){
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            OnFalling.Invoke();
        }
    }
}
