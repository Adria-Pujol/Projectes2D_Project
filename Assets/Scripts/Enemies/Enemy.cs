using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public float health = 100f;
        public GameObject bullets;
        [SerializeField] private bool dropBullets;

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
            Destroy(gameObject);
        }
    }
}