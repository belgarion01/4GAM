using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.VFX;

public class DestroyableGround : MonoBehaviour
{
    public UnityEvent OnHit;
    public VisualEffect smokeVFX;
    public int smokePerHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Boule")){
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            for (int i = 0; i < smokePerHit; i++)
            {
                VisualEffect vfx = Instantiate(smokeVFX, GetRandomPointSphere(collision.contacts[0].point, 1), Quaternion.identity);
                Destroy(vfx, 10f);
            }         
            //vfx.SendEvent("OnPlay");           
            OnHit.Invoke();
        }
    }

    Vector3 GetRandomPointSphere(Vector3 center, float radius) {
        Vector3 point = center + Random.insideUnitSphere * radius;
        return point;
    }
}
