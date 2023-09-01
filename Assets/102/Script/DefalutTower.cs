using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class DefalutTower : Tower
{
  

    #region 
    [Header("������")]
    [SerializeField] private GameObject lazer;
    [SerializeField] private GameObject lazerend;
    [SerializeField] private GameObject BigLazer;
    [SerializeField] private Transform lazerPos;
    [SerializeField] private int raydistance;
    [SerializeField] private float AttackDelayTime;
    [SerializeField] private float chargeTime;
    [SerializeField] private float upgradeChargeTime;
    [SerializeField] private float bigValue;
    [SerializeField] private bool isBigLazer;


    #endregion

    #region 
    [Header("����ĳ��Ʈ")]
    RaycastHit2D lrhit;
    public RaycastHit2D[] lrhits;
    public LineRenderer lr;
    [SerializeField] public LayerMask whatisEnemy;
    [SerializeField] public LayerMask whatisEnd;
    Vector2 pos;
    public float rayDistance = 200f;
    #endregion

    #region 
    [Header("�ִϸ��̼�")]
    [SerializeField] private GameObject animationPrefab;
    private GameObject currentAnimation; // ���� ��� ���� �ִϸ��̼� ������
    #endregion

    [SerializeField] float Atk;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;

    }
    void Update()
    {
       
            Move();
            SetRotation();
            Attack();
            TimeContinue();

    }
    void TimeContinue()
    {
        AttackDelayTime = Time.time;
    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            LrDraw();
            BigLazerShotReady();


        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            LrDisable();
        }
    }

    void LrDisable()
    {
        lr.enabled = false;
    }

    void BigLazerShotReady()
    {
        bigValue += 0.0005f;

        if (bigValue >= 1)
        {
            isBigLazer = true;
            BigLazerCreate();
        }
    }
    void BigLazerCreate()
    {
        GameObject Big = Instantiate(BigLazer, lazerPos.transform.position, lazerPos.transform.rotation);

        Destroy(Big, 2);
        Invoke("BigLazerfalse", 2f);

        bigValue = 0f;
    }
    void BigLazerfalse()
    {
        isBigLazer = false;
    }
    void LrDraw()
    {
        lr.SetPosition(0, lazerPos.transform.position);


        bool hitEnemy = false;

        if (lrhit = Physics2D.Raycast(transform.position, transform.up, raydistance, whatisEnd))
        {
            lr.SetPosition(1, lrhit.point);
            lr.enabled = true;


            if (lrhit.collider.CompareTag("Monster"))
            {
                if (lrhit.collider != null)
                {
                    GameObject hitObject = lrhit.collider.gameObject;

                    hitObject.GetComponent<M_Base>().Damage(Atk);


                    hitEnemy = true;
                }
            }
        }


        if (!hitEnemy)
        {
            lrhits = Physics2D.RaycastAll(transform.position, transform.up, raydistance, whatisEnemy);

            foreach (RaycastHit2D hit in lrhits)
            {
                if (hit.collider.CompareTag("Monster"))
                {
                    if (hit.collider != null)
                    {
                        GameObject hitObject = hit.collider.gameObject;

                        hitObject.GetComponent<M_Base>().Damage(Atk);


                        lr.SetPosition(1, hit.point);
                        lr.enabled = true;

                        Instantiate(lazerend, hit.point, Quaternion.identity);

                        break; //�̰͸� ����� ������ ������ ���� 
                    }
                }
            }
        }


        lr.enabled = true;

    }
    void SetRotation()
    {
        if (angle > 1.5 && angle < 1.6)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius / 1.5f;


        transform.position = new Vector3(posX, posY);
    }

    void Move()
    {
        if (isBigLazer != true)
        {
            if (angle < leftLockAngle)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {

                    angle = angle + Time.deltaTime * angularSpeed;
                    transform.Rotate(0, 0, rote);
                    if (angle >= leftLockAngle)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                }
            }

            if (angle > rightLockAngle)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {

                    angle = angle + Time.deltaTime * -angularSpeed;
                    transform.Rotate(0, 0, -rote);
                    if (angle <= rightLockAngle)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                }
            }
        }
    }

}