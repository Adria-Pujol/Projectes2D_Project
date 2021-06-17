using UnityEngine;
using Player;
using System;
using System.Threading;

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
        private bool _isFacingRight = false;
        private Transform _player;

        public float timerPatrol = 0.0f;
        private Vector3 patrolVec = new Vector3(-1, 0, 0);
        private bool izquierda = true;
        public bool patrol = false;

        public void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            _generalChecker = transform.Find("GeneralChecker").GetComponent<GeneralChecker>();
            _groundChecker = transform.Find("GroundChecker").GetComponent<EnemyGroundChecker>();
        }

        public void FixedUpdate()
        {
            if (gameObject.GetComponent<Enemy>().dead) speed = 0;

            if (_player)
            {
                //timerPatrol = 0.0f;
                Vector3 dist2 = new Vector3(_player.position.x - transform.position.x, _player.position.y - transform.position.y, _player.position.z - transform.position.z);
                dist2 = Vector3.Normalize(dist2);
                transform.position = transform.position + (speed * dist2 * Time.fixedDeltaTime);
                patrol = false;

                if (dist2.x >= 0 && _isFacingRight == true)
                {
                    Flip();
                }
                if (dist2.x <= 0 && _isFacingRight == false)
                {
                    Flip();
                }

            }
            else
            {
                patrol = true;
                Patrol();
                
            }
            timerPatrol = timerPatrol + Time.fixedDeltaTime;
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

            transform.position = transform.position + (speed * patrolVec * Time.fixedDeltaTime);
            if (patrolVec.x >= 0 && _isFacingRight)
            {
                Flip();
            }
            if (patrolVec.x <= 0 && !_isFacingRight)
            {
                Flip();
            }

            if (timerPatrol >= 8)
            {
                patrolVec.x = patrolVec.x * (-1);
                timerPatrol = 0;
            }
        }

        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            transform.rotation = Quaternion.Euler(0, _isFacingRight ? 0 : 180, 0);
        }
    }
}