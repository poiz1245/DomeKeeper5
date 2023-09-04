using UnityEngine;

public class M_Base : MonoBehaviour
{
    public M_StateMachine stateMachine { get; private set; }
    public Animator ani { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Transform domeCenter { get; private set; }

    protected bool destroyed = false;

    [Header("Stat")]
    public float HP = 1;
    public float Atk = 1;

    public int faceX { get; private set; }
    public bool facingRight { get; private set; }
    public Vector2 zero { get; private set; }

    protected virtual void Awake()
    {
        stateMachine = new M_StateMachine();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        domeCenter = GameObject.Find("Dome_Center").GetComponent<Transform>();
        zero = new Vector2(0, 0);
        faceX = 1;
        facingRight = true;
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        stateMachine.currentState.Update();

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


        if (HP <= 0)
        {
            Dead();
        }

    }
    public void Damage(float Atk)
    {
        if (HP > 0)
        {
            HP -= Atk;
        }
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
