using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PrefabLauncher : MonoBehaviour
{
    public Transform origin;
    public GameObject instantiatedPrefab;
    public GameObject targetPrefab;
    public float timeBeforeLaunch = 1f;
    public float launchForce = 20f;

    public float lauchCooldown;
    private float currentLaunchCooldown;
    bool launchReady = true;
    bool launchWasReady = true;

    public LayerMask clickableMask;

    public UnityEvent OnClickSucces;
    public UnityEvent OnClickFail;
    public UnityEvent OnLaunching;
    public UnityEvent OnLaunchReady;

    void Update()
    {
        if (currentLaunchCooldown < lauchCooldown) currentLaunchCooldown += Time.deltaTime;
        launchReady = currentLaunchCooldown < lauchCooldown ? false : true;
        if (launchReady && !launchWasReady) {
            OnLaunchReady.Invoke();
        }
        launchWasReady = launchReady;
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, clickableMask)&&launchReady)
            {
                Instantiate(targetPrefab, hit.point, Quaternion.Euler(-90f, 0f, 0f));
                StartCoroutine(LaunchPrefab((hit.point-origin.position).normalized));
                currentLaunchCooldown = 0f;
                OnClickSucces.Invoke();
            }
            else {
                OnClickFail.Invoke();
            }
        }
    }

    IEnumerator LaunchPrefab(Vector3 direction) {
        yield return new WaitForSeconds(timeBeforeLaunch);
        GameObject bol = Instantiate(instantiatedPrefab, origin.position, Quaternion.identity);
        bol.GetComponent<Rigidbody>().AddForce(direction * launchForce, ForceMode.VelocityChange);
        OnLaunching.Invoke();
    }
}
