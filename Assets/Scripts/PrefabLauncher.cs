using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PrefabLauncher : MonoBehaviour
{
    public Transform origin;
    public GameObject instantiatedPrefab;
    public GameObject targetPrefab;
    public float timeBeforeLaunch = 1f;
    public float launchForce = 20f;

    public float lauchCooldown;
    private float currentLaunchCooldown;
    public Slider cooldownSlider;
    bool launchReady = true;

    public LayerMask clickableMask;

    public UnityEvent OnClickSucces;
    public UnityEvent OnClickFail;
    public UnityEvent OnLaunching;
    public UnityEvent OnLaunchReady;

    private void Awake()
    {
        cooldownSlider.maxValue = lauchCooldown;
    }


    void Update()
    {
        if (currentLaunchCooldown < lauchCooldown) currentLaunchCooldown += Time.deltaTime;
        launchReady = currentLaunchCooldown < lauchCooldown ? false : true;
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, clickableMask)&&launchReady)
            {
                Instantiate(targetPrefab, hit.point, Quaternion.Euler(-90f, 0f, 0f));
                StartCoroutine(LaunchPrefab(mouseRay.direction));
                currentLaunchCooldown = 0f;
                OnClickSucces.Invoke();
            }
            else {
                OnClickFail.Invoke();
            }
        }
        UpdateUI();
    }

    IEnumerator LaunchPrefab(Vector3 direction) {
        yield return new WaitForSeconds(timeBeforeLaunch);
        GameObject bol = Instantiate(instantiatedPrefab, transform.position, Quaternion.identity);
        bol.GetComponent<Rigidbody>().AddForce(direction * launchForce, ForceMode.VelocityChange);
        OnLaunching.Invoke();
    }

    void UpdateUI() {
        cooldownSlider.value = currentLaunchCooldown;
    }
}
