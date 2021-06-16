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
    [SerializeField] public Animator animator;

    public void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void FixedUpdate()
    {
        
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 5)
        {
            HUD.transform.Find("HealthBar").gameObject.SetActive(true);
        }
        else
        {
            HUD.transform.Find("HealthBar").gameObject.SetActive(false);
        } 
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
    

    public void XFadeFinished()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
