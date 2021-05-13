using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public float health = 100f;
        public List<GameObject> collectableList;

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
            int randomCollectable = Random.Range(0, collectableList.Count);
            Instantiate(collectableList[randomCollectable], transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}