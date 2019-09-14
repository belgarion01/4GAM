using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLauncher : MonoBehaviour
{
    public LayerMask groundMask;
    public GameObject instantiatedPrefab;
    public GameObject targetPrefab;

    public float timeBeforeLaunch = 1f;
    public float launchForce = 20f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, groundMask) && Input.GetMouseButtonDown(0)) {
            Instantiate(targetPrefab, hit.point, Quaternion.Euler(-90f, 0f, 0f));
            StartCoroutine(LaunchPrefab(mouseRay.direction));
        }
    }

    IEnumerator LaunchPrefab(Vector3 direction) {
        yield return new WaitForSeconds(timeBeforeLaunch);
        GameObject bol = Instantiate(instantiatedPrefab, transform.position, Quaternion.identity);
        bol.GetComponent<Rigidbody>().AddForce(direction * launchForce, ForceMode.VelocityChange);
    }
}
