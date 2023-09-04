using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_Player : MonoBehaviour
{
    public GameObject drill;
    public int facingDir { get; private set; } = 1;
    bool facingRight = true;
    public float layerChangeTime;
    public float layerChangeDelay = 1;

    [Header("Move Info")]
    public float Speed = 3f;
    public float jumpForce = 5f;

    [Header("Collision Info")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask whatIsGround;

    [Header("Score Info")]
    public float redjemScore = 0;
    public float greenjemScore = 0;
    public float bluejemScore = 0;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rbody { get; private set; }
    //public SpriteRenderer spriteRender { get; private set; }
    #endregion

    #region States
    public WJ_PlayerStateMachine stateMachine { get; private set; }
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
        stateMachine.Initialize(idleState);
    }

    void Update()
    {
        stateMachine.currentState.Update();

        LayerChangeControll();

        if (Input.GetMouseButton(0))
        {
            drill.SetActive(true);
            anim.SetBool("Dig", true);
        }
        if (!Input.GetMouseButton(0))
        {
            drill.SetActive(false);
            anim.SetBool("Dig", false);
        }

    }


    void LayerChangeControll() => layerChangeTime -= Time.deltaTime;

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rbody.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x,
            groundCheck.position.y - groundCheckDistance));

    }
    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    public void FlipController(float _x)
    {
        if (_x > 0 && facingRight)
        {
            Flip();
        }
        else if (_x < 0 && !facingRight)
        {
            Flip();
        }
    }
}
