using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public static float health = 7f;
        public float invulnerableTotalTime;
        public float invulnerableCurrentTime;
        public bool canRecieveDmg;
        public Transform respawnPosition;
        public bool isFacingRight;
        public float deadTimer;
        private bool dead = false;
        private bool deadTimerOut = false;
        public bool shakeCamera = false;
        public float shakeDuration = 1;
        public float shakeAmount;
        public float decreaseFactor = 1.0f;
        public Transform camTransform;
        Vector3 originalPos;
        public Collider2D colliderCapsule;
        public float spriteTimer = 0.12f;

        private Rigidbody2D _body;

        public void Awake()
        {
            invulnerableCurrentTime = invulnerableTotalTime;
            _body = GetComponent<Rigidbody2D>();
            isFacingRight = gameObject.GetComponent<PlayerController>().isFacingRight;
            deadTimer = 1.5f;
        }

        public void FixedUpdate()
        {
            isFacingRight = gameObject.GetComponent<PlayerController>().isFacingRight;
            if (invulnerableCurrentTime < invulnerableTotalTime)
            {
                invulnerableCurrentTime += Time.deltaTime;
                SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
                if (spriteTimer > 0)
                {
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
                    spriteTimer -= Time.deltaTime;
                }
                else
                {
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 255f);
                    spriteTimer = 0.12f;
                }
            }
            else
            {
                canRecieveDmg = true;
                SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 255f);
                spriteTimer = 0.12f;
            }

            if (shakeCamera)
            {
                originalPos = camTransform.position;
                if (shakeDuration > 0)
                {
                    camTransform.position += Random.insideUnitSphere * shakeAmount;
                    shakeDuration -= Time.deltaTime * decreaseFactor;

                }
                else
                {
                    shakeDuration = 1;
                    camTransform.localPosition = originalPos;
                    shakeCamera = false;
                }
            }

            if (dead && deadTimer > 0)
            {
                deadTimer -= Time.deltaTime;
            }
            else if (dead && deadTimer <= 0)
            {
                deadTimerOut = true;
                Death();
            }
                
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
            {
                if (canRecieveDmg)
                {
                    health -= 1;
                    invulnerableCurrentTime = 0f;
                    canRecieveDmg = false;
                    ShakeCamera();
                }

                if (health <= 0) Death();
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Boss")) invulnerableCurrentTime += Time.deltaTime;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
            {
                if (canRecieveDmg)
                {
                    health -= 1;
                    invulnerableCurrentTime = 0f;
                    canRecieveDmg = false;
                    ShakeCamera();
                }
                else
                {
                    Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), colliderCapsule);
                    invulnerableCurrentTime += Time.deltaTime;
                }

                if (health <= 0) Death();
            }
            
        }

        public void TakeDamage(float dmg)
        {
            if (canRecieveDmg)
            {
                health -= dmg;
                invulnerableCurrentTime = 0f;
                canRecieveDmg = false;
                ShakeCamera();
            }

            if (health <= 0) Death();
        }

        public void Death()
        {
            gameObject.GetComponent<PlayerController>().isDead = true;
            if (deadTimerOut)
            {
                gameObject.GetComponent<PlayerController>().enabled = true;
                gameObject.GetComponent<PlayerController>().animator.SetBool("Die", false);
                PlayerController.ammunition = 100;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
                health = 7f;
                deadTimer = 1.5f;
                dead = false;
                deadTimerOut = false;
                gameObject.transform.position = respawnPosition.position;
            }
            else
            {
                FindObjectOfType<audioManager>().Play("PlayerDeath");
                gameObject.GetComponent<PlayerController>().animator.SetBool("Die", true);
                gameObject.GetComponent<PlayerController>()._body.velocity = new Vector2(0, 0);
                gameObject.GetComponent<PlayerController>().resetVariables();
                gameObject.GetComponent<PlayerController>().enabled = false;
                health = 0;
                dead = true;
            }
        }

        private void ShakeCamera()
        {
            shakeCamera = true;
        }
    }
}