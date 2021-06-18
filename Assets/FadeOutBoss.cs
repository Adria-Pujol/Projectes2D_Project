using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutBoss : MonoBehaviour
{
    public Animator animator;
    public void FadeOut()
    {
        animator.SetBool("FadeOut", true);
    }

    public void ChangeToCinematic()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
