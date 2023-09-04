using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_Player : MonoBehaviour
{
    [Header("Move Info")]
    public float Speed = 3f;
    public float jumpForce = 5f;

    public float redjemScore = 0;
    public float greenjemScore = 0;
    public float bluejemScore = 0;

    public float xInput;
    public float yInput;

    public GameObject drill;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rbody { get; private set; }
    public SpriteRenderer spriteRender { get; private set; }
    #endregion

    #region States
    public WJ_PlayerStateMachine stateMachine {  get; private set; }
    public WJ_PlayerIdleState idleState { get; private set; }
    public WJ_PlayerMoveState moveState { get; private set; }
    public WJ_PlayerUpState upState { get; private set; }
    public WJ_PlayerDownState downState { get; private set; }
    public WJ_PlayerDigState digState { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new WJ_PlayerStateMachine();
        idleState = new WJ_PlayerIdleState(this, stateMachine, "Idle");
        moveState = new WJ_PlayerMoveState(this, stateMachine, "Move");
        upState = new WJ_PlayerUpState(this, stateMachine, "Up");
        downState = new WJ_PlayerDownState(this, stateMachine, "Down");
        digState = new WJ_PlayerDigState(this, stateMachine, "Dig");
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        stateMachine.Initialize(idleState);
        drill.SetActive(false);
    }

    void Update()
    {
        stateMachine.currentState.Update();

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0))
        {
            drill.SetActive(true);
            anim.SetBool("Dig", true);
            stateMachine.ChangeState(digState);
        }
        else
        {
            drill.SetActive(false);
            anim.SetBool("Dig", false);
            stateMachine.ChangeState(idleState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(upState);
        }
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rbody.velocity  = new Vector2(_xVelocity, _yVelocity);
    }

    public void Flip()
    {
        if (rbody.velocity.x > 0)
        {
            spriteRender.flipX = true;
        }
        else
        {
            spriteRender.flipX = false;
        }
    }
}
