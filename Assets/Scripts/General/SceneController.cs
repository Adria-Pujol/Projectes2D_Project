using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] public float currentScene;

    private void FixedUpdate()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            HUD.transform.Find("HealthBar").gameObject.SetActive(true);
        }
        else
        {
            HUD.transform.Find("HealthBar").gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
