using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public Animator animator;
        public float health = 100f;
        public GameObject bullets;
        [SerializeField] private bool dropBullets;
        public bool dead;


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
            if(dropBullets) Instantiate(bullets, transform.position, transform.rotation);
            dead = true;
            animator.SetBool("isDead", true);
        }

        public void Destroyed()
        {
            Destroy(gameObject);
        }
    }
}