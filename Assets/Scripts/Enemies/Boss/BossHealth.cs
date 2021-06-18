using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public float health;
    public Slider slider;
    public GameObject canvas;

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
        canvas.transform.Find("FadeOut").GetComponent<FadeOutBoss>().FadeOut();
        DestroyAllRockObjects();
        DestroyAllBulletObjects();
        Destroy(gameObject);
    }
    
    public void DestroyAllRockObjects()
    {
        GameObject[] GameObjects = GameObject.FindGameObjectsWithTag("Rock");
 
        for (int i = 0; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
        }
    }
    
    public void DestroyAllBulletObjects()
    {
        GameObject[] GameObjects = GameObject.FindGameObjectsWithTag("EnemyBullet");
 
        for (int i = 0; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
        }
    }
}
