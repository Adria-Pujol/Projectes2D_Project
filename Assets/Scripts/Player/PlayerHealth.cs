using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public float health = 7f;
        public float knockback;
        public float invulnerableTotalTime;
        public float invulnerableCurrentTime;
        public bool canRecieveDmg;
        public Transform respawnPosition;
        public bool isFacingRight;
        public float deadTimer;

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
                //Physics2D.IgnoreCollision(gameObject.GetComponent<PolygonCollider2D>(), GameObject.FindWithTag("Enemy").GetComponent<BoxCollider2D>());
            }
            else
            {
                canRecieveDmg = true;
            }
                
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy")) return;
            if (canRecieveDmg)
            {
                health -= 1;
                invulnerableCurrentTime = 0f;
                canRecieveDmg = false;
            }

            if (health <= 0) Death();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy")) invulnerableCurrentTime += Time.deltaTime;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy")) return;
            if (canRecieveDmg)
            {
                health -= 1;
                invulnerableCurrentTime = 0f;
                canRecieveDmg = false;
            }
            else
            {
                invulnerableCurrentTime += Time.deltaTime;
            }

            if (health <= 0) Death();
        }

        public void TakeDamage(float dmg)
        {
            if (canRecieveDmg)
            {
                health -= dmg;
                invulnerableCurrentTime = 0f;
                canRecieveDmg = false;
            }

            if (health <= 0) Death();
        }

        public void Death()
        {
            gameObject.GetComponent<PlayerController>().isDead = true;
            if (deadTimer <= 0)
            {
                gameObject.transform.position = respawnPosition.position;
                gameObject.GetComponent<PlayerController>().animator.SetBool("Die", false);
                deadTimer = 1.5f;
                gameObject.GetComponent<PlayerController>()._input.Enable();
                health = 7f;
            }
            else
            {
                gameObject.GetComponent<PlayerController>().animator.SetBool("Die", true);
                gameObject.GetComponent<PlayerController>()._input.Disable();
                gameObject.GetComponent<PlayerController>()._body.velocity = new Vector2(0, 0);
                deadTimer -= Time.deltaTime;
            }
        }
    }
}