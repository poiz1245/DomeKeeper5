using UnityEngine;

public class M_Diver : M_Moving
{
    public M_DiverAttack attack { get; private set; }
    public M_DiverAttackSuccess attackSuccess { get; private set; }
    public M_DiverAttackDead attackDead { get; private set; }
    public M_DiverBack back { get; private set; }
    public M_DiverBackDead1 backDead1 { get; private set; }
    public M_DiverBackDead2 backDead2 { get; private set; }

    public int isAttacking { get; set; }


    public GameObject warning;


    protected override void Awake()
    {
        base.Awake();
        attack = new M_DiverAttack(this, stateMachine, "Attack", this);
        attackSuccess = new M_DiverAttackSuccess(this, stateMachine, "AttackSuccess", this);
        attackDead = new M_DiverAttackDead(this, stateMachine, "AttackDead", this);
        back = new M_DiverBack(this, stateMachine, "Back", this);
        backDead1 = new M_DiverBackDead1(this, stateMachine, "BackDead1", this);
        backDead2 = new M_DiverBackDead2(this, stateMachine, "BackDead2", this);

        isAttacking = 1;
    }


    protected override void Start()
    {
        base.Start();
        stateMachine.Initiate(attack);
        float angle = Mathf.Atan2(Getdir().x, Getdir().y) * Mathf.Rad2Deg;
        if (angle > 90)
        {
            transform.rotation = Quaternion.Euler(0, 0, (135 - angle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, (225 - angle));
        }

    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (isAttacking == 1) stateMachine.ChangeState(attackDead);
            else if (isAttacking == 0) stateMachine.ChangeState(backDead1);
            else stateMachine.ChangeState(backDead2);
        }
    }

    public void Back()
    {
        stateMachine.ChangeState(back);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (stateMachine.currentState != back)
        {
            if (collision.CompareTag("Dome"))
            {
                stateMachine.ChangeState(attackSuccess);
            }
        }
    }

    private void OnBecameInvisible()
    {
        Vector2 pos = Getdir();

        if (Mathf.Abs(pos.x) > 22)
        {
            pos.y = pos.y * 22 / pos.x;
            pos.x = 22;
        }

        if (Mathf.Abs(pos.y) > 23)
        {
            pos.x = pos.x * 24 / pos.y;
            pos.y = 12;
        }

        GameObject warningPrefab =  Instantiate(warning, -pos, transform.rotation);
        warningPrefab.SetActive(true);
        Destroy(warningPrefab,5);

        Invoke("Invisible", 2);
    }

    void Invisible()
    {
        stateMachine.ChangeState(attack);
    }
}
