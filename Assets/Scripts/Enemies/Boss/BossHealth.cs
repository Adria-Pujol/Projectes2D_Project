using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public float health;
    public Slider slider;

    public void FixedUpdate()
    {
        slider.value = health;
        if (health <= 20)
        {
            GetComponent<BossAI>().isEnrage = true;
        }
        else
        {
            GetComponent<BossAI>().isEnrage = false;
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
