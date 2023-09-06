using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class M_Base : MonoBehaviour
{
    public M_StateMachine stateMachine { get; private set; }
    public Animator ani { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Transform domeCenter { get; private set; }

    protected bool destroyed = false;


    public float currentHP1;
    public float idleTime1 = 0.15f;
    public float idleTimer1 = 0;


    public float currentHP2;
    public float idleTimer2 = 0;
    public float idleTime2 = 15f;
    public bool stun;

    [Header("Stat")]
    public float HP;
    public float HP1 = 10;
    public float HP2 = 0;
    public float Atk = 1;
    
    public int faceX { get; private set; }
    public bool facingRight { get; private set; }
    public Vector2 zero { get; private set; }


    protected Collider2D collision;

    protected virtual void Awake()
    {
        stateMachine = new M_StateMachine();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        domeCenter = GameObject.Find("Dome_Center").GetComponent<Transform>();
        zero = new Vector2(0, 0);
        faceX = 1;
        facingRight = true;

        HP = HP1 + HP2;
    }

    protected virtual void Start()
    {
        currentHP1 = HP1;
        currentHP2 = HP2;
    }

    protected virtual void Update()
    {

        stateMachine.currentState.Update();

        HP = HP1 + HP2;

        if (transform.position.x > domeCenter.position.x && facingRight)
        {
            facingRight = !facingRight;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x < domeCenter.position.x && !facingRight)
        {
            facingRight = !facingRight;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        if (facingRight) faceX = 1;
        else faceX = -1;



        if ( currentHP2 != HP2)
        {
            currentHP2 = HP2;
            idleTimer2 = 0;
            Stun(0f);
            stun = true;
        }
        else if (idleTimer2 >= idleTime2)
        {
            Stun(1f);
            stun = false;
        }

        idleTimer2 += Time.deltaTime;


        if (HP <= 0)
        {
            Dead();
        }

    }

    public void ChangeStunTime(float x) => idleTime2 = x;
    protected virtual void Stun(float x)
    {
        ani.SetFloat("Stun", x);
    }

    public void Damage1(float Atk)
    {
            HP1 -= Atk;
    }

    public void Damage2(float Atk)
    {
        HP2 -= Atk;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dome"))
        {
            this.collision = collision;
        }
        
    }

    protected void SetDamage()
    {
        if(collision !=null)
        collision.GetComponent<Dome>().SetDamage(Atk);
    }

    protected virtual void Dead()
    {

    }
    protected void Destroy()
    {
        destroyed = true;
        Destroy(gameObject);
    }

    protected void OffRigidbody2D()
    {
        if (gameObject.GetComponent<CapsuleCollider2D>() != null)
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

        if (gameObject.GetComponent<CircleCollider2D>() != null)
            gameObject.GetComponent<CircleCollider2D>().enabled = false;

        if (gameObject.GetComponent<EdgeCollider2D>() != null)
            gameObject.GetComponent<EdgeCollider2D>().enabled = false;

        if (gameObject.GetComponent<BoxCollider2D>() != null)
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
