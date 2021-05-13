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

        private Rigidbody2D _body;

        public void Awake()
        {
            invulnerableCurrentTime = invulnerableTotalTime;
            _body = GetComponent<Rigidbody2D>();
            isFacingRight = gameObject.GetComponent<PlayerController>().isFacingRight;
        }

        public void FixedUpdate()
        {
            isFacingRight = gameObject.GetComponent<PlayerController>().isFacingRight;
            if (invulnerableCurrentTime < invulnerableTotalTime)
                invulnerableCurrentTime += Time.deltaTime;
            else
                canRecieveDmg = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy")) return;
            if (canRecieveDmg)
            {
                health -= 1;
                invulnerableCurrentTime = 0f;
                canRecieveDmg = false;
                Vector2 direction = collision.transform.position - transform.position;
                direction.y = 0;
                /*if (isFacingRight)
                    _body.AddForce(new Vector2(transform.position.x * knockback, 0), ForceMode2D.Impulse);
                else
                    _body.AddForce(new Vector2(transform.position.x * knockback, 0), ForceMode2D.Impulse);*/
                _body.AddForce(direction.normalized * knockback, ForceMode2D.Impulse);
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
                if (isFacingRight)
                {
                    _body.AddForce(new Vector2(transform.position.x * knockback, 0), ForceMode2D.Impulse);
                }
                else
                {
                    _body.AddForce(new Vector2(transform.position.x * knockback, 0), ForceMode2D.Impulse);
                }
                    
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
            gameObject.transform.position = respawnPosition.position;
            gameObject.GetComponent<PlayerController>().isDead = true;
            health = 7f;
        }
    }
}