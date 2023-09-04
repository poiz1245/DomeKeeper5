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

    float angle;


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
        stateMachine.Initiate(attackSuccess);


        Vector2 pos = Getdir();

        pos = new Vector2(Mathf.Abs(pos.x), Mathf.Abs(pos.y));

        while (pos.x > 22.5f || pos.y > 18.1f)
        {

            if (pos.x > 22.5f)
            {
                pos.y = pos.y * 22.5f / pos.x;
                pos.x = 22.5f;
            }

            if (pos.y > 18.1f) // pos = getdir+9.6
            {
                pos.x = (18.1f * pos.x) / pos.y;
                pos.y = 18.1f;
            }
        }

        pos.x *= faceX;
        if (transform.position.x < 0)
        {
            pos.x = -pos.x;
        }
        pos.y -= 8.6f;
        pos.x += 0.5f;


        Vector2 dir = Getdir();
        angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

        GameObject warningPrefab = Instantiate(warning, pos, Quaternion.Euler(0, 0, 180 - angle));
        GameObject warningPrefab2 = Instantiate(warning, pos, Quaternion.Euler(0, 0, 210 - angle));
        GameObject warningPrefab3 = Instantiate(warning, pos, Quaternion.Euler(0, 0, 150 - angle));

        warningPrefab.SetActive(true);
        warningPrefab2.SetActive(true);
        warningPrefab3.SetActive(true);

        Destroy(warningPrefab, 2.6f);
        Destroy(warningPrefab2, 2.6f);
        Destroy(warningPrefab3, 2.6f);


        Invoke("Invisible", 2);
        angle = Mathf.Atan2(Getdir().x, Getdir().y) * Mathf.Rad2Deg;
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
            Dead();
        }
    }

    protected override void Dead()
    {
        if (isAttacking == 1) stateMachine.ChangeState(attackDead);
        else if (isAttacking == 0) stateMachine.ChangeState(backDead1);
        else stateMachine.ChangeState(backDead2);
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
        if (!destroyed)
        {

            Vector2 pos = Getdir();

            pos = new Vector2(Mathf.Abs(pos.x), Mathf.Abs(pos.y));

            while (pos.x > 22.5f || pos.y > 18.1f)
            {

                if (pos.x > 22.5f)
                {
                    pos.y = pos.y * 22.5f / pos.x;
                    pos.x = 22.5f;
                }

                if (pos.y > 18.1f) // pos = getdir+9.6
                {
                    pos.x = (18.1f * pos.x) / pos.y;
                    pos.y = 18.1f;
                }
            }

            if (transform.position.x < 0)
            {
                pos.x = -pos.x;
            }
            pos.y -= 8.6f;
            pos.x += 0.5f;


            /*            Vector2 pos = Getdir();

                        pos = new Vector2(Mathf.Abs(pos.x), Mathf.Abs(pos.y));

                        while (pos.x > 23 || pos.y > 22.6f)
                        {

                            if (pos.x > 23)
                            {
                                pos.y = pos.y * 23 / pos.x;
                                pos.x = 23;
                            }

                            if (pos.y > 22.6f) // pos = getdir+9.6
                            {
                                pos.x = (22.6f * pos.x) / pos.y;
                                pos.y = 22.6f;
                            }
                        }

                        pos.x *= -faceX;
                        pos.y -= 9.6f;*/

            Vector2 dir = Getdir();
            angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

            GameObject warningPrefab = Instantiate(warning, pos, Quaternion.Euler(0, 0, 180 - angle));
            GameObject warningPrefab2 = Instantiate(warning, pos, Quaternion.Euler(0, 0, 210 - angle));
            GameObject warningPrefab3 = Instantiate(warning, pos, Quaternion.Euler(0, 0, 150 - angle));

            warningPrefab.SetActive(true);
            warningPrefab2.SetActive(true);
            warningPrefab3.SetActive(true);

            Destroy(warningPrefab, 2.6f);
            Destroy(warningPrefab2, 2.6f);
            Destroy(warningPrefab3, 2.6f);

            Invoke("Invisible", 2);
        }
    }

    void Invisible()
    {
        stateMachine.ChangeState(attack);
    }
}
