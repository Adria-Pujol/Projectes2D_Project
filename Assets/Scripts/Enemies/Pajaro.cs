using System;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;

namespace Enemies
{
    public class Pajaro : MonoBehaviour
    {
        [Header("Movement")] public float speed;

        [SerializeField] private bool isGround;

        [SerializeField] private bool isWall;

        [SerializeField] private bool isObject;

        [SerializeField] private bool isEnemy;

        private Rigidbody2D _body;

        private GeneralChecker _generalChecker;
        private EnemyGroundChecker _groundChecker;
        private bool _isFacingRight = true;
        private Transform _player;

        public void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
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
                Vector3 dist2 = new Vector3(_player.position.x - transform.position.x, _player.position.y - transform.position.y, _player.position.z - transform.position.z);
                dist2 = Vector3.Normalize(dist2);
                transform.position = transform.position + (speed * dist2 * Time.fixedDeltaTime);
                //_body.MovePosition(_body.position + new Vector2(1, 1));
                //_body.MovePosition(_body.position + (dist2 * speed * Time.fixedDeltaTime));

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

        private void OnTriggerStay2D(Collider2D collision)
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
        }
    }
}