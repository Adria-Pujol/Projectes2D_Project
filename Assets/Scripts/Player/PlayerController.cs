using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("General")]
        public Rigidbody2D _body;
        public InputPlayer _input;
        public int collectables;
        private GroundChecker _groundChecker;
        private GroundChecker _groundChecker1;
        private WallChecker _wallChecker;
        private WeaponScript _weaponScript;
        
        [Header("Layers")] 
        [SerializeField] private LayerMask groundLayer;

        [Header("Movement")] 
        public bool isFacingRight = true;
        public float _movInputCtx;
        [SerializeField] private float maxSpeed;
        private bool _isTopWall;
        
        [Header("Jumping")] 
        public bool isJumping;
        [SerializeField] private float jumpVel;
        [SerializeField] private float fallMult;
        [SerializeField] private float shortJumpMult;
        public float timerJump = 0.5f;


        [Header("Wall")] 
        public float jumpWallValY;
        public float fallTimer;
        public float initialFallTimer;
        [SerializeField] private float slideSpeed;

        [Header("Shooting")]
        [SerializeField]
        private bool _isShooting;
        public float timerReset = 0.2f;
        public int activeWeapon = 1;
        public bool hasSwapped;
        public float swapTime;
        public float totalSwapTime;
        public float ammunition;
        public float timer;
        public float startTime;
        private bool _resetShooting = true;

        [Header("Melee")] 
        [SerializeField]
        private bool _isHitting;
        private bool _hasBeenPressed;

        [Header("Booleans")]
        public bool isGround;
        public bool isWall;
        public bool isShifting;
        public bool isDead;
        public bool isSwapping;
        public bool isRightGround;
        public bool isSpike;
        public bool isInObject;
        
        [Header("Slow State")] 
        public bool slowState;
        public float slowTimer;
        public float slowTotalTime;

        [Header("Dash")] 
        public float totalDashTime;
        public float currentDashTime;
        [SerializeField] private float dashSpeed;
        [SerializeField] private float initialDashSpeed;
        private bool _isDashing;
        private bool _hasDashed;

        [Header("Animation")] 
        [SerializeField] public Animator animator;

        private void Awake()
        {
            _input = new InputPlayer();
            _input.Player.MovementLeftRight.performed += ctx => MovementLeftRight(ctx);
            _input.Player.Jump.started += ctx => Jump(ctx);
            _input.Player.Jump.canceled += ctx => Jump(ctx);
            _input.Player.Shoot.performed += ctx => Shoot(ctx);
            _input.Player.Melee.performed += ctx => Melee(ctx);
            _input.Player.GrabWall.performed += ctx => GrabWall(ctx);
            _input.Player.Dash.performed += ctx => Dash(ctx);
            _input.Player.SwapWeapon.performed += ctx => SwapWeapon(ctx);
            timer = startTime;
            swapTime = totalSwapTime;
            dashSpeed = initialDashSpeed;
            currentDashTime = totalDashTime;
            fallTimer = initialFallTimer;
            _body = GetComponent<Rigidbody2D>();
            _groundChecker1 = transform.Find("GroundChecker").GetComponent<GroundChecker>();
            _groundChecker = transform.Find("GroundChecker").GetComponent<GroundChecker>();
            _wallChecker = transform.Find("WallChecker").GetComponent<WallChecker>();
            _weaponScript = gameObject.GetComponent<WeaponScript>();
            transform.Find("EyesColor1").gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }

        private void FixedUpdate()
        {
            //Checking if player is in Ground
            isGround = _groundChecker1.isGrounded;
            //Checking if player is in TopWall
            _isTopWall = _groundChecker.isTopWalled;
            //Checking if player is in Wall
            isWall = _wallChecker.isWall;
            //Checking if player is hitting a Ground/Platform
            isRightGround = _wallChecker.isRightGround;
            //Checking if player fall into Spike
            isSpike = _groundChecker1.isSpike;
            //Checking if player is in Object;
            isInObject = _groundChecker1.isInObject;

            //Movement
            if (isRightGround && !isWall && _movInputCtx != 0 && !isInObject)
            {
                _body.velocity = new Vector2(0, -50);
            }

            if (!isWall && !isGround && !_isTopWall)
            {
                if (fallTimer > 0)
                {
                    fallTimer -= Time.deltaTime;
                }
            }
            if (isSpike)
            {
                fallTimer = initialFallTimer;
            }
            else
            {
                if(isGround || _isTopWall || isInObject)
                {
                    if (fallTimer <= 0)
                    {
                        GetComponent<PlayerHealth>().health -= 1;
                        if (GetComponent<PlayerHealth>().health == 0)
                        {
                            GetComponent<PlayerHealth>().Death();
                        }
                    }
                    fallTimer = initialFallTimer;
                }
            }
            
            if (GetComponent<PlayerHealth>().health == 0)
            {
                animator.SetBool("Die", true);
                GetComponent<PlayerHealth>().Death();
            }
            
            if (!isWall)
            {
                if (slowState)
                {
                    if (isDead)
                    {
                        slowState = false;
                        slowTimer = 0;
                        isDead = false;
                    }

                    if (slowTimer <= 0)
                    {
                        slowState = false;
                    }
                    else
                    {
                        if (_movInputCtx == 0)
                        {
                            _body.velocity = new Vector2(0, _body.velocity.y);
                            animator.SetFloat("Walk", 0);
                        }
                        else if (_movInputCtx < 0)
                        {
                            if (isFacingRight) Flip();
                            isFacingRight = false;
                            _body.velocity = new Vector2(-maxSpeed/2, _body.velocity.y);
                            animator.SetFloat("Walk", maxSpeed);
                        }
                        else
                        {
                            if (!isFacingRight) Flip();
                            isFacingRight = true;
                            _body.velocity = new Vector2(maxSpeed/2, _body.velocity.y);
                            animator.SetFloat("Walk", maxSpeed);
                        }

                        slowTimer -= Time.deltaTime;
                    }
                }
                else
                {
                    if (_movInputCtx == 0)
                    {
                        _body.velocity = new Vector2(0, _body.velocity.y);
                        animator.SetFloat("Walk", 0);
                    }
                    else if (_movInputCtx < 0)
                    {
                        if (isFacingRight) Flip();
                        isFacingRight = false;
                        _body.velocity = new Vector2(-maxSpeed, _body.velocity.y);
                        animator.SetFloat("Walk", maxSpeed);
                    }
                    else
                    {
                        if (!isFacingRight) Flip();
                        isFacingRight = true;
                        _body.velocity = new Vector2(maxSpeed, _body.velocity.y);
                        animator.SetFloat("Walk", maxSpeed);
                    }
                }
            }

            //Jumping
            if (isGround && isJumping || _isTopWall && isJumping || isInObject && isJumping)
            {
                animator.SetBool("Jump", true);
                _body.velocity = new Vector2(_body.velocity.x, jumpVel);
            }

            if (isJumping && _body.velocity.y > 0)
            {
                _body.gravityScale = fallMult;
            }
            else
            {    
                _body.gravityScale = shortJumpMult;
            }
            if (!isJumping && isGround)
            {
                animator.SetBool("Jump", false);
            }

            //Shooting
            if (activeWeapon == 2)
                startTime = 0.05f;
            else
                startTime = 0.2f;

            if (_isShooting && activeWeapon == 2)
            {
                if (ammunition > 0)
                {
                    if (_resetShooting)
                    {
                        _weaponScript.Shoot();
                        ammunition -= 1;
                        _resetShooting = false;
                    }

                    if (timer <= 0)
                    {
                        _weaponScript.Shoot();
                        ammunition -= 1;
                        timer = startTime;
                    }
                    else
                    {
                        timer -= Time.deltaTime;
                    }
                }
            }
            else if (!_isShooting && activeWeapon == 2)
            {
                if (timerReset > 0)
                {
                    timerReset -= Time.deltaTime;
                }
                else
                {
                    _resetShooting = true;
                    timerReset = 0.05f;
                }

                timer = startTime;
            }

            if (_isShooting && activeWeapon == 1)
            {
                if (_resetShooting)
                {
                    _resetShooting = false;
                    _weaponScript.Shoot();
                }

                if (timer < 0)
                {
                    _weaponScript.Shoot();
                    timer = startTime;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
            else if (!_isShooting && activeWeapon == 1)
            {
                if (timerReset > 0)
                {
                    timerReset -= Time.deltaTime;
                }
                else
                {
                    _resetShooting = true;
                    timerReset = 0.2f;
                }

                timer = startTime;
            }

            if (isSwapping)
            {
                if (!hasSwapped && swapTime < 0)
                {
                    if (activeWeapon == 1)
                    {
                        activeWeapon++;
                        transform.Find("EyesColor1").gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    else
                    {
                        activeWeapon = 1;
                        transform.Find("EyesColor1").gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                    }
                    hasSwapped = true;
                    swapTime = totalSwapTime;
                }
                else
                {
                    hasSwapped = false;
                }
            }
            else
            {
                swapTime -= Time.deltaTime;
            }

            //Wall 
            switch (isWall)
            {
                case true when !isShifting && !_isTopWall:
                    _body.velocity = new Vector2(_body.velocity.x, -slideSpeed * Time.deltaTime);
                    break;
                case true when isShifting && !isGround && !_isTopWall:
                {
                    _isShooting = false;
                    if (_movInputCtx != 0)
                    {
                        _body.velocity = new Vector2(_body.velocity.x, jumpWallValY);
                    }
                    else
                    {
                        _body.velocity = new Vector2(_body.velocity.x, 0);
                        _body.gravityScale = 0;
                    }
                    break;
                }
            }

            if (!_isDashing || _hasDashed)
            {
                animator.SetBool("Dash", false);
            }

            //Dash
            if (isGround && _isDashing)
            {
                animator.SetBool("Dash", true);
                if (!_hasDashed)
                {
                    if (_body.velocity.x == 0)
                    {
                        if (isFacingRight)
                        {
                            if (currentDashTime >= 0)
                            {
                                _body.velocity = new Vector2(dashSpeed * 50f, _body.velocity.y);
                                dashSpeed -= Time.deltaTime;
                                currentDashTime -= 0.25f;
                            }
                            else
                            {
                                _hasDashed = true;
                                currentDashTime = totalDashTime;
                                dashSpeed = initialDashSpeed;
                            }
                        }
                        else
                        {
                            if (currentDashTime >= 0)
                            {
                                _body.velocity = new Vector2(-dashSpeed * 40f, _body.velocity.y);
                                dashSpeed -= Time.deltaTime;
                                currentDashTime -= 0.25f;
                            }
                            else
                            {
                                _hasDashed = true;
                                currentDashTime = totalDashTime;
                                dashSpeed = initialDashSpeed;
                            }
                        }
                    }
                    else
                    {
                        if (currentDashTime >= 0)
                        {
                            _body.velocity = new Vector2(_body.velocity.x, _body.velocity.y) * dashSpeed;
                            dashSpeed -= Time.deltaTime;
                            currentDashTime -= 0.25f;
                        }
                        else
                        {
                            _hasDashed = true;
                            currentDashTime = totalDashTime;
                            dashSpeed = initialDashSpeed;
                        }
                    }
                }
            }
            else
            {
                _hasDashed = false;
            }
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Collectable"))
            {
                collectables += 1;
                collision.GetComponent<Collectable>().Collected();
            }

            if (collision.CompareTag("Bullets"))
            {
                ammunition += 20;
                if (ammunition > 100)
                {
                    ammunition = 100;
                }
                Destroy(collision.gameObject);
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Object")) _hasBeenPressed = false;
        }

        public void OnTriggerStay2D(Collider2D collision)
        {
            //Flip Object
            if (!collision.CompareTag("Object")) return;
            if (!_isHitting || _hasBeenPressed) return;
            var objTransform = collision.GetComponent<Transform>();
            var rotation = objTransform.rotation;
            rotation = new Quaternion(rotation.x, rotation.y, 180,
                180);
            objTransform.rotation = rotation;
            _hasBeenPressed = true;
        }

        private void MovementLeftRight(InputAction.CallbackContext ctx)
        {
            _movInputCtx = ctx.ReadValue<float>();
            if (isFacingRight && _movInputCtx < 0 || !isFacingRight && _movInputCtx > 0) Flip();
        }

        private void Jump(InputAction.CallbackContext ctx)
        {
            if (ctx.phase == InputActionPhase.Started)
                isJumping = true;
            else if (ctx.phase == InputActionPhase.Canceled) isJumping = false;
        }

        private void Shoot(InputAction.CallbackContext ctx)
        {
            _isShooting = ctx.ReadValue<float>() != 0;
        }

        private void Melee(InputAction.CallbackContext ctx)
        {
            _isHitting = ctx.ReadValue<float>() != 0;
        }

        private void GrabWall(InputAction.CallbackContext ctx)
        {
            isShifting = ctx.ReadValue<float>() != 0;
        }

        private void Dash(InputAction.CallbackContext ctx)
        {
            _isDashing = ctx.ReadValue<float>() != 0;
        }

        private void SwapWeapon(InputAction.CallbackContext ctx)
        {
            isSwapping = ctx.ReadValue<float>() != 0;
        }

        public void MakeSlow()
        {
            slowState = true;
            slowTimer = slowTotalTime;
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
        }

        public void resetVariables()
        {
            _movInputCtx = 0;
            _isDashing = false;
            _isHitting = false;
            _isShooting = false;
            isJumping = false;
            isShifting = false;
        }
    }
}