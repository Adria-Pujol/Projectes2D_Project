using System;
using System.Collections;
using UnityEngine;

public class AkiraChargingScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float multiplier;
    private Rigidbody2D _body;
    private bool _isRightGround;
    private bool _isGround;
    private AkiraRightGroundChecker _rightGroundChecker;
    private AkiraGroundChecker _groundChecker;
    
    [SerializeField] public Animator animator;
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _body.gravityScale = multiplier;
        _rightGroundChecker = transform.Find("RightGroundCheck").GetComponent<AkiraRightGroundChecker>();
        _groundChecker = transform.Find("GroundCheck").GetComponent<AkiraGroundChecker>();
    }

    private void FixedUpdate()
    {
        //Check if boss is touching ground
        _isGround = _groundChecker.isGrounded;
        //Check if in front of the boss there is a ground
        _isRightGround = _rightGroundChecker.isRightGround;
        
        _body.velocity = new Vector2(speed, _body.velocity.y);
        if (_isRightGround)
        {
            Jump();
            animator.SetBool("IsJumping", true);
        }

        if (_isGround) animator.SetBool("IsJumping", false);
    }
    
    private void Jump()
    {
        _body.velocity = new Vector2(_body.velocity.x, jumpSpeed);
        _body.gravityScale = multiplier;
    }
}
