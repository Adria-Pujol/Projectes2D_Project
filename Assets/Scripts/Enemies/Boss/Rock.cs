using System;
using Player;
using UnityEngine;

namespace Enemies.Boss
{
    public class Rock : MonoBehaviour
    {

        [SerializeField] private float bulletDamage = 1f;
        [SerializeField] private float timeAlive = 1.5f;
        [SerializeField] private float timeAliveFromCollision;
        [SerializeField] private Rigidbody2D body;
        private float _timer;
        private float _timerCollision;
        [SerializeField] private Animator rockAnim;
        [SerializeField] private float animTime = 0.4f;

        private void Start()
        {
            _timer = timeAlive;
            _timerCollision = timeAliveFromCollision;
            rockAnim.SetBool("IsBoom", false);
            animTime = 0.4f;
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
                if (animTime <= 0)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    body.velocity = new Vector2(0, 0);
                    body.gravityScale = 0;
                    rockAnim.SetBool("IsBoom", true);
                    animTime -= Time.deltaTime;
                }
            }

            if (collision.CompareTag("Ground") || collision.CompareTag("Wall"))
            {
                if (animTime <= 0)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    body.velocity = new Vector2(0, 0);
                    body.gravityScale = 0;
                    rockAnim.SetBool("IsBoom", true);
                    animTime -= Time.deltaTime;
                }
            }
            if (collision.CompareTag("Object"))
            {
                if (_timerCollision > 0)
                {
                    _timerCollision -= Time.deltaTime;
                }
                else
                {
                    if (animTime <= 0)
                    {
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        body.velocity = new Vector2(0, 0);
                        body.gravityScale = 0;
                        rockAnim.SetBool("IsBoom", true);
                        animTime -= Time.deltaTime;
                    }
                    collision.GetComponent<ObjectHP>().takeDamage(bulletDamage);
                    _timerCollision = timeAliveFromCollision;
                }
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
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
                if (animTime <= 0)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    body.velocity = new Vector2(0, 0);
                    body.gravityScale = 0;
                    rockAnim.SetBool("IsBoom", true);
                    animTime -= Time.deltaTime;
                }
            }

            if ( (collision.CompareTag("Ground") || collision.CompareTag("Wall") ) && GetComponent<AudioSource>().isPlaying == false)
            {
                if (animTime <= 0)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    body.velocity = new Vector2(0, 0);
                    body.gravityScale = 0;
                    GetComponent<AudioSource>().Play();
                    rockAnim.SetBool("IsBoom", true);
                    animTime -= Time.deltaTime;
                }
            }
            if (collision.CompareTag("Object"))
            {
                if (_timerCollision > 0)
                {
                    _timerCollision -= Time.deltaTime;
                }
                else
                {
                    if (animTime <= 0)
                    {
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        body.velocity = new Vector2(0, 0);
                        body.gravityScale = 0;
                        rockAnim.SetBool("IsBoom", true);
                        animTime -= Time.deltaTime;
                    }
                    collision.GetComponent<ObjectHP>().takeDamage(bulletDamage);
                    _timerCollision = timeAliveFromCollision;
                }
            }
        }
    }
}