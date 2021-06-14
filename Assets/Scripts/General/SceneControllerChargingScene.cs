using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerChargingScene : MonoBehaviour
{
    
    [SerializeField] private Animator animator;
    private bool hasBeenFaded = false;
    [SerializeField] private float timer = 1.0f;

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

    void XFadeFinished()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
