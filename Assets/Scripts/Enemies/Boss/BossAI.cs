using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
using Player;

public class BossAI : MonoBehaviour
{
    //General Stuff
    [Header("General Settings")] [SerializeField]
    private Transform player;
    public Rigidbody2D _body;
    private BossGroundChecker _groundChecker;
    private BossRightGroundChecker _rightGroundChecker;
    private BossWallChecker _wallChecker;
    [SerializeField] private bool isFacingRight = false;
    [SerializeField] private float totalSkillTime;
    public float timeBetweenSkills;
    public int number;
    public bool isDoingSkill = false;
    public float tiredCooldown;
    public float totalTiredCooldown;
    public bool numberSelected = false;

    //Idle State

    //Movement State
    [Header("Movement")] [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float multiplier;
    private float _slowDown;
    public bool _isGround;
    private bool _isRightGround;
    private bool _isWall;

    //Attack1 State
    [Header("Sprint Attack")] [SerializeField]
    private float attack1Cooldown;
    private bool isDoingAttack1;
    [SerializeField] private float attack1TotalCooldown;
    public float _sprintSpeed;

    //Attack2 State
    [Header("Roar Rock Fall Attack")] [SerializeField]
    private GameObject rock;
    private bool isDoingAttack2;
    [SerializeField] private float xLeftPoint;
    [SerializeField] private float xRightPoint;
    [SerializeField] private float yDownPoint;
    [SerializeField] private float yTopPoint;
    [SerializeField] private float maximumRocks;
    [SerializeField] private float attack2Cooldown;
    [SerializeField] private float attack2TotalCooldown;

    //Attack3 State
    [Header("Slime Attack")] [SerializeField]
    private Transform shootingPoint;
    private bool isDoingAttack3;
    [SerializeField] private float attack3Cooldown;
    [SerializeField] private float attack3TotalCooldown;


    //Rage State
    public bool isEnrage = false;

    //Testing Variables
    private BossInput _inputBoss;

    private void Awake()
    {
        _inputBoss = new BossInput();
        _body = GetComponent<Rigidbody2D>();
        _groundChecker = transform.Find("GroundCheck").GetComponent<BossGroundChecker>();
        _rightGroundChecker = transform.Find("RightGroundCheck").GetComponent<BossRightGroundChecker>();
        _wallChecker = transform.Find("WallCheck").GetComponent<BossWallChecker>();
        _body.gravityScale = multiplier;
        attack1Cooldown = attack1TotalCooldown;
        attack2Cooldown = attack2TotalCooldown;
        attack3Cooldown = attack3TotalCooldown;
        timeBetweenSkills = totalSkillTime;
        tiredCooldown = totalTiredCooldown;
    }

    private void OnEnable()
    {
        _inputBoss.Enable();
    }

    private void OnDisable()
    {
        _inputBoss.Disable();
    }

    private void FixedUpdate()
    {
        //Check if boss is touching ground
        _isGround = _groundChecker.isGrounded;
        //Check if in front of the boss there is a ground
        _isRightGround = _rightGroundChecker.isRightGround;
        //Check if in front of the boss there is a wall
        _isWall = _wallChecker.isWall;

        if (isEnrage)
        {
            attack2TotalCooldown = 3;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            attack2TotalCooldown = 1;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        
        if (timeBetweenSkills <= 0)
        {
            GameObject.Find("Exclamation").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Exclamation").GetComponent<Animator>().enabled = false;
            isDoingSkill = true;
            if (!numberSelected)
            {
                number = Random.Range(0, 2);
                numberSelected = true;
            }
        }
        else
        {
            MovementState();
            timeBetweenSkills -= 0.1f;
            attack1Cooldown = attack1TotalCooldown;
            attack2Cooldown = attack2TotalCooldown;
            attack3Cooldown = attack3TotalCooldown;
            numberSelected = false;
            if (timeBetweenSkills <= 8)
            {
                GameObject.Find("Exclamation").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Exclamation").GetComponent<Animator>().enabled = true;
            }
        }

        if (isDoingSkill && !isEnrage)
        {
            if (number == 0)
            {
                isDoingAttack1 = true;
                isDoingAttack2 = false;
                isDoingAttack3 = false;
            }
            else if (number == 1)
            {
                isDoingAttack1 = false;
                isDoingAttack2 = true;
                isDoingAttack3 = false;
            }
        }
        else if (isDoingSkill && isEnrage)
        {
            if (number == 0)
            {
                isDoingAttack1 = false;
                isDoingAttack2 = true;
                isDoingAttack3 = false;
            }
            else if (number == 1)
            {
                isDoingAttack1 = false;
                isDoingAttack2 = false;
                isDoingAttack3 = true;
            }
        }

        if (isDoingAttack1)
        {
            if (attack1Cooldown > 0)
            {
                Attack1State();
                attack1Cooldown -= 0.1f;
            }
            else if (attack1Cooldown <= 0)
            {
                isDoingAttack1 = false;
                isDoingSkill = false;
                timeBetweenSkills = totalSkillTime;
            }
        }
        else if (isDoingAttack2)
        {
            if (attack2Cooldown >= 0)
            {
                _body.velocity = new Vector2(0, _body.velocity.y);
                Attack2State();
                attack2Cooldown -= 0.1f;
            }
            else if (attack2Cooldown < 0)
            {
                
                isDoingAttack2 = false;
                isDoingSkill = false;
                timeBetweenSkills = totalSkillTime;
            }
        }
        else if (isDoingAttack3)
        {
            if (attack3Cooldown >= 0)
            {
                _body.velocity = new Vector2(0, _body.velocity.y);
                Attack3State();
                attack3Cooldown -= 0.1f;
            }
            else if (attack3Cooldown < 0)
            {
                
                isDoingAttack3 = false;
                isDoingSkill = false;
                timeBetweenSkills = totalSkillTime;
            }
        }
    }

    //States
    private void MovementState()
    {
        if (isEnrage)
        {
            jumpSpeed = 240;
            multiplier = 160;
            speed = 100;
        }
        else
        {
            speed = 70;
            jumpSpeed = 120;
            multiplier = 80;
        }

        if (_isWall) Flip();
        if (_isRightGround)
        {
            Jump();
        }

        var velocity = _body.velocity;
        velocity = isFacingRight ? new Vector2(speed, velocity.y) : new Vector2(-speed, velocity.y);
        _body.velocity = velocity;
    }

    private void Attack1State()
    {
        jumpSpeed = 240;
        multiplier = 160;
        if (_isWall) Flip();
        if (_isRightGround)
        {
            Jump();
        }

        var velocity = _body.velocity;
        velocity = isFacingRight ? new Vector2(_sprintSpeed, velocity.y) : new Vector2(-_sprintSpeed, velocity.y);
        
        _body.velocity = velocity;
    }

    private void Attack2State()
    {
        Vector2 positionFromSpawnZone =
            new Vector2(Random.Range(xLeftPoint, xRightPoint), Random.Range(yDownPoint, yTopPoint));
        GameObject rockSpawned = Instantiate(rock, positionFromSpawnZone, rock.transform.rotation);
        rockSpawned.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Random.Range(-50, -200));
    }

    private void Attack3State()
    {
        Vector2 randomPosition = new Vector2(Random.Range(shootingPoint.position.x - 7, shootingPoint.position.x + 7),
            Random.Range(shootingPoint.position.y - 7, shootingPoint.position.y + 7));
        BulletPooler.instance.SpawnFromPool("EnemyBullet", randomPosition, shootingPoint.rotation);
    }
    //Triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) player = collision.gameObject.transform;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) player = null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) player = null;
    }

    //Auxiliar Functions
    private void Jump()
    {
        _body.velocity = new Vector2(0, jumpSpeed);
        _body.gravityScale = multiplier;
        FindObjectOfType<audioManager>().Play("Bark1");
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
    }
}