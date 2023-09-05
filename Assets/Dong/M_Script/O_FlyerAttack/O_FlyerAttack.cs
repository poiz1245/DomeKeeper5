using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_FlyerAttack : M_Moving
{
    public O_FlyerAttackAttack attack { get; private set; }
    public O_FlyerAttackHit hit { get; private set; }
    Vector2 dir { get; set; }


    protected override void Awake()
    {
        base.Awake();
        attack = new O_FlyerAttackAttack(this, stateMachine, "Attack", this);
        hit = new O_FlyerAttackHit(this, stateMachine, "Hit", this);
    }

    protected override void Start()
    {
        base.Start();
        dir = Getdir().normalized;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg ;

        if(transform.position.x < 0)
        transform.rotation = Quaternion.Euler(0,0,135 - angle);
        else
        transform.rotation = Quaternion.Euler(0, 0,225 - angle);


        stateMachine.Initiate(attack);
        
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dome"))
        {
            stateMachine.ChangeState(hit);
        }
    }
}
