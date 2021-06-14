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
    [SerializeField] private Animator animator;
    private bool hasBeenFaded = false;
    [SerializeField] private float timer = 1.0f;

    public void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void FixedUpdate()
    {
        if (!hasBeenFaded)
        {
            if (timer > 0)
            {
                animator.Play("Fade_Out");
                hasBeenFaded = true;
                timer = 1.0f;
            }
            else
            {
                timer -= Time.deltaTime;
            }
            
        }
        else
        {
            animator.Play("Fade_Idle");
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FadeLevel();
        }
    }
    
    public void FadeLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void XFadeFinished()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
