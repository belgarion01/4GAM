using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

public class DestroyByTime : MonoBehaviour
{
    
    public float timeBeforeDestroy;
    public bool beginTimerOnStart;
    private bool timerActive = false;

    private void Start()
    {
        timerActive = beginTimerOnStart;
    }

    private void Update()
    {
        if (!timerActive) return;
        Destroy(gameObject, timeBeforeDestroy);
    }

    public void BeginTimer() {
        timerActive = true;
    }
}
