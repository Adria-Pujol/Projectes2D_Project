using UnityEngine;
using Player;
using System;

namespace Enemies
{
    public class ShooterPatroler : MonoBehaviour
    {
        [Header("Movement")] public float speed;

        [SerializeField] private bool isGround;

        [SerializeField] private bool isWall;

        [SerializeField] private bool isObject;

        [SerializeField] private bool isEnemy;

        [SerializeField] public float timer;

        private Rigidbody2D _body;

        private GeneralChecker _generalChecker;
        private EnemyGroundChecker _groundChecker;
        private bool _isFacingRight = true;
        private Transform _player;
        private float distRotation;

        public float timeBetweenShoots;

        public Transform firePoint;

        public void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            timer = timeBetweenShoots;
        }

        private void Start()
        {
            _generalChecker = transform.Find("GeneralChecker").GetComponent<GeneralChecker>();
            _groundChecker = transform.Find("GroundChecker").GetComponent<EnemyGroundChecker>();
        }

        public void FixedUpdate()
        {
            //Checking if enemy is colliding to a Wall
            isWall = _generalChecker.isWall;
            //Checking if enemy is in Ground
            isGround = _groundChecker.isGrounded;
            //Checking if enemy is colliding to an Object
            isObject = _generalChecker.isObject;
            //Checking if enemy is colliding to an Enemy
            isEnemy = _generalChecker.isEnemy;

            if (_player)
            {
                if (isWall || !isGround || isObject || isEnemy)
                {
                    Flip();
                    var velocity = _body.velocity;
                    velocity =
                        _isFacingRight ? new Vector2(speed, velocity.y) : new Vector2(-speed, velocity.y);
                    _body.velocity = velocity;
                    _player = null;
                }
                else
                {
                    _body.velocity = new Vector2(0, _body.velocity.y);
                    if (timer < 0)
                    {
                        Shoot();
                        timer = timeBetweenShoots;
                    }
                    else
                    {
                        timer -= Time.deltaTime;
                    }
                }
            }
            else
            {
                Patrol();
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) _player = collision.gameObject.transform;
        }

        public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) _player = collision.gameObject.transform;
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) _player = null;
        }

        private void Patrol()
        {
            if (isWall || !isGround || isObject || isEnemy) Flip();

            var velocity = _body.velocity;
            velocity = _isFacingRight ? new Vector2(speed, velocity.y) : new Vector2(-speed, velocity.y);
            _body.velocity = velocity;
        }

        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            transform.rotation = Quaternion.Euler(0, _isFacingRight ? 0 : 180, 0);
            firePoint.rotation = Quaternion.identity;
            Debug.Log(firePoint.rotation);
        }

        private void Shoot()
        {
            Vector2 dist = new Vector2(_player.position.x - firePoint.position.x, _player.position.y - firePoint.position.y);

            distRotation = AngleBetweenVector2(dist, new Vector2(1, 0));

            if (dist.x < 0 && _isFacingRight)
            {
                Flip();
            }
            else if (dist.x > 0 && !_isFacingRight)
            {
                Flip();
            }

            firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, distRotation));

            BulletPooler.instance.SpawnFromPool("EnemyBullet", firePoint.position, firePoint.rotation);
            firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, 360 - distRotation));
        }

        private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
        {
            Vector2 diference = vec2 - vec1;
            float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
            return Vector2.Angle(Vector2.right, diference) * sign;
        }
    }
}