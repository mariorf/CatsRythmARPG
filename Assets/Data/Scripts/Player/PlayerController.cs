using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 10f;

    public Vector3 move;

    public Animator animator;
    
    public Rigidbody rb;
    
    public bool canMove = true;
    
    public InputActionAsset playerInput;
    
    
    
    private SpriteRenderer spriteRenderer;
    
    private Vector3 movement;
    
    private Vector2 moveInput;
    
    private Vector2 lookDirection;
    
    private bool facingRight = true;
    
    private bool isBackwards;
    
    
    //STATES
    public PlayerStateMachine stateMachine { get; private set; }
    
    public PlayerIdleState idleState { get; private set; }
    
    public PlayerRunningState RunningState { get; private set; }
    
    public PlayerAttackingState AttackingState { get; private set; }
    
    public PlayerDashingState DashingState { get; private set; }
    
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine);
        RunningState = new PlayerRunningState(this, stateMachine);
        AttackingState = new PlayerAttackingState(this, stateMachine);
        DashingState = new PlayerDashingState(this, stateMachine);
        
        
    }

    private void Start()
    {
        InputManager.Instance.OnMoveEvent += OnMove;
        stateMachine.Initialize(idleState);
    }
    
    private void Update()
    {
        stateMachine.currentState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        MovePlayer(); 
        stateMachine.currentState.PhysicsUpdate();  
    }

    public void MovePlayer()
    {
        if (!canMove)
        {
            return;
        }
        
            
        if (move.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (move.x < 0 && facingRight)
        {
            Flip();
        }
            
        rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.y * speed);
    }
    
    private void Flip()
    {
        facingRight = !facingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
    
    public void SetAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public void OnMove(Vector2 value)
    {
        move = value;
        move.Normalize();
    }
    
    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            stateMachine.ChangeState(AttackingState);
        }
    }
    
    public void OnDash(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            stateMachine.ChangeState(DashingState);
        }
    }
    
    public void SetIdleState()
    {
        stateMachine.ChangeState(idleState);
    }
    
    private void AnimationTriggerEvent(AnimationTriggerType animationTriggerType)
    {
        stateMachine.currentState.AnimationTriggerEvent(animationTriggerType);
    }


    public enum AnimationTriggerType
    {
        Idle,
        Walk,
        Run,
        Jump,
        Land,
        Attack,
        Dash,
        Death,
    }
}
