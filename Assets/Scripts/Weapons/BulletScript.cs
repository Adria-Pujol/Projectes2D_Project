using Enemies;
using Player;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 20f;

    [SerializeField] private float bulletDamage = 20f;

    [SerializeField] private Rigidbody2D body;

    [SerializeField] private float _timer;

    [SerializeField] private float timeAlive = 1.5f;
    [SerializeField] private float timeAliveFromCollision;
    private float _timerCollision;

    [SerializeField] private Sprite bullet01;
    [SerializeField] private Sprite bullet02;

    private GameObject player;

    private void Start()
    {
        _timer = timeAlive;
        _timerCollision = timeAliveFromCollision;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy) body.velocity = transform.right * bulletSpeed;
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
            _timer = timeAlive;
        }

        /*if (player.GetComponent<PlayerController>().activeWeapon == 1)
        {
            GameObject.Find("Bullet").GetComponent<SpriteRenderer>().sprite = bullet01;
        }
        else if (player.GetComponent<PlayerController>().activeWeapon == 2)
        {
            GameObject.Find("Bullet").GetComponent<SpriteRenderer>().sprite = bullet02;
        }*/
    }

    private void OnEnable()
    {
        body.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<Enemy>();
            if (enemy != null) enemy.TakeDamage(bulletDamage);
            gameObject.SetActive(false);
        }

        if (collision.CompareTag("Boss"))
        {
            var boss = collision.GetComponent<BossHealth>();
            if (boss != null) boss.TakeDamage(bulletDamage);
            gameObject.SetActive(false);
            
        }

        if (collision.CompareTag("Ground") || collision.CompareTag("Wall")) gameObject.SetActive(false);

        if (collision.CompareTag("Object"))
        {
            if (_timerCollision > 0)
            {
                _timerCollision -= Time.deltaTime;
            }
            else
            {
                gameObject.SetActive(false);
                _timerCollision = timeAliveFromCollision;
            }
        }
    }
}