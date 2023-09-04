using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class M_Beast : M_Moving
{
    #region State
    public M_BeastMove move { get; private set; } 
    public M_BeastAttack attack { get; private set; }
    public M_BeastGroundDead groundDead { get; private set; }
    public M_BeastHowling howling { get; private set; }
    public M_BeastJump jump { get; private set; }
    public M_BeastWallDead wallDead { get; private set; }
    #endregion


    public bool howl { get; private set; }

    public Vector2 jumpPower;
    public bool onGround { get;  set; }

    public float howlX { get; private set; }
    public float JumpX { get; private set; }

    public float currnetHP;


    protected override void Awake()
    {
        base.Awake();

        move = new M_BeastMove(this,stateMachine,"Move",this);
        attack = new M_BeastAttack(this, stateMachine, "Attack", this);
        groundDead = new M_BeastGroundDead(this, stateMachine, "GroundDead", this);
        howling = new M_BeastHowling(this, stateMachine, "Howling", this);
        jump = new M_BeastJump(this, stateMachine, "Jump", this);
        wallDead = new M_BeastWallDead(this, stateMachine, "WallDead", this);
        rb.gravityScale = 0;

        howlX = Random.Range(15f, 17f);
        JumpX = Random.Range(10f, 12f);
        howl = false;
        onGround = true;
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initiate(move);
        currnetHP = HP1;
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.A))
        {
            Dead();
        }
    }

    public void HowlOn()
    {
        howl = true;
        stateMachine.ChangeState(move);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dome"))
        {
            stateMachine.ChangeState(attack);
        }
    }

    protected override void Dead()
    {
        if (onGround) stateMachine.ChangeState(groundDead);  
        else stateMachine.ChangeState(wallDead);
    }

}
