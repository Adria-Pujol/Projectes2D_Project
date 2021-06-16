using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerChargingScene : MonoBehaviour
{
    [SerializeField] public Animator animator;
    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
    

    public void XFadeFinished()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
