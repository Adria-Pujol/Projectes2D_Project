using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health = 100f;

    public void FixedUpdate()
    {
        if (health <= 50)
        {
            GetComponent<BossAI>().isEnrage = true;
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
        Destroy(gameObject);
    }
}
