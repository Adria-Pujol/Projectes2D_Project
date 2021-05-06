using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public float health = 100f;

        public void TakeDamage(float dmg)
        {
            health -= dmg;
            if (health <= 0) Destroy(gameObject);
        }
    }
}