using UnityEngine;

namespace Enemies
{
    public class PatrolEnemy : MonoBehaviour
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
                    Vector2 dist = new Vector2(_player.position.x - transform.position.x, _player.position.y - transform.position.y);
                    if (dist.x < 0 && _isFacingRight)
                    {
                        Flip();
                    }
                    else if (dist.x > 0 && !_isFacingRight)
                    {
                        Flip();
                    }
                    transform.position = Vector2.MoveTowards(transform.position,
                        new Vector2(_player.position.x, transform.position.y), speed * Time.deltaTime * 2);
                    
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