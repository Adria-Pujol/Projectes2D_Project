using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerChargingScene : MonoBehaviour
{
    
    private bool hasBeenFaded = false;
    [SerializeField] private float timer = 1.0f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            XFadeFinished();
        }
    }

    void XFadeFinished()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
