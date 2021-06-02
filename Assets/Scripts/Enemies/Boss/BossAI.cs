using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BossAI : MonoBehaviour
{
    //General Stuff
    [Header("General Settings")] 
    [SerializeField] private Transform player;
    private Rigidbody2D _body;
    private BossGroundChecker _groundChecker;
    private BossRightGroundChecker _rightGroundChecker;
    private BossWallChecker _wallChecker;
    [SerializeField] private bool isFacingRight = false;
    
    //Idle State
    
    //Movement State
    [Header("Movement")] 
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float multiplier;
    private float _slowDown;
    private bool _isGround;
    private bool _isRightGround;
    private bool _isWall;
    
    //Attack1 State

    //Attack2 State

    //Attack3 State

    //Rage State
    
    //Testing Variables
    private InputPlayer _inputBoss;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _groundChecker = transform.Find("GroundCheck").GetComponent<BossGroundChecker>();
        _rightGroundChecker = transform.Find("RightGroundCheck").GetComponent<BossRightGroundChecker>();
        _wallChecker = transform.Find("WallCheck").GetComponent<BossWallChecker>();
        _body.gravityScale = multiplier;
        //_inputBoss.Player.Shoot.performed += ctx => Attack1(ctx);
    }

    private void FixedUpdate()
    {
        //Check if boss is touching ground
        _isGround = _groundChecker.isGrounded;
        //Check if in front of the boss there is a ground
        _isRightGround = _rightGroundChecker.isRightGround;
        //Check if in front of the boss there is a wall
        _isWall = _wallChecker.isWall;
        MovementState();
    }

    //States
    private void MovementState()
    {
        if (_isWall) Flip();
        if (_isRightGround)
        {
            Jump();
        }
        var velocity = _body.velocity;
        velocity = isFacingRight ? new Vector2(speed, velocity.y) : new Vector2(-speed, velocity.y);
        _body.velocity = velocity;
        
    }

    private void Attack1(InputAction.CallbackContext ctx)
    {
        
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
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
    }
}
