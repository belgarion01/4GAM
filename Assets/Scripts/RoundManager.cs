using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartRound() {

    }

    public void BeginRound() {

    }

    public void EndRound(GameObject gameObject) {
        transform.position = gameObject.transform.position;
    }
}
