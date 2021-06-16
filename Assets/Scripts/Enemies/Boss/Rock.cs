using System;
using Player;
using UnityEngine;

namespace Enemies.Boss
{
    public class Rock : MonoBehaviour
    {

        [SerializeField] private float bulletDamage = 1f;
        [SerializeField] private Rigidbody2D body;
        [SerializeField] private Animator rockAnim;
        [SerializeField] private float animTime;
        private bool _isDoingAnimation = false;

        private void Start()
        {
            rockAnim.SetBool("IsBoom", false);
        }

        public void FixedUpdate()
        {
            if (_isDoingAnimation)
            {
                animTime -= Time.deltaTime;
            }

            if (animTime <= 0)
            {
                gameObject.SetActive(false);
                _isDoingAnimation = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                var playerHp = collision.GetComponent<PlayerHealth>();
                var player = collision.GetComponent<PlayerController>();

                if (playerHp != null)
                {
                    playerHp.TakeDamage(bulletDamage);
                    player.MakeSlow();
                }

                body.velocity = new Vector2(0, 0);
                body.gravityScale = 0;
                rockAnim.SetBool("IsBoom", true);
                animTime -= Time.deltaTime;
                _isDoingAnimation = true;
            }

            if (collision.CompareTag("Ground") || collision.CompareTag("Wall"))
            {
                body.velocity = new Vector2(0, 0);
                body.gravityScale = 0;
                rockAnim.SetBool("IsBoom", true);
                animTime -= Time.deltaTime;
                _isDoingAnimation = true;
            }
        }
    }
}