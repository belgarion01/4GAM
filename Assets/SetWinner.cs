using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Experimental.VFX;

public class SetWinner : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public VisualEffect winnerVFX;
    public Vector3 offset;

    public GameObject ooo;

    public void _SetWinner(GameObject obj) {
        cam.Follow = obj.transform;
        cam.LookAt = obj.transform;
        cam.gameObject.SetActive(true);

        Instantiate(winnerVFX, obj.transform.position + (Vector3.up + offset), Quaternion.identity, obj.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _SetWinner(ooo);
    }
}
