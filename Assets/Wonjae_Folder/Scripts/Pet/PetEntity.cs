using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PetEntity : MonoBehaviour
{
    [Header("�� ����")]
    [Tooltip("���� ���� ���ݷ�")]
    [SerializeField] private float petDamage;
    protected float petSpeed = 2.5f;

    [Tooltip("�� ���� ���ð�")]
    [SerializeField] protected float petCooldownTimer = 100.0f;
    private float petCooldownTimerUpgrade = 60.0f;

    [Tooltip("footPos : �Ʒ����� ä��")]
    [SerializeField] protected Transform footPos;
    [Tooltip("toothPos : ������ ä��")]
    [SerializeField] protected Transform toothPos;

    [Header("������ ������ ��")]
    public float redjemScore = 0f;
    public float greenjemScore = 0f;
    public float bluejemScore = 0f;
    [Tooltip("Pet�� ���� �� �ִ� �ִ� ���� �����Դϴ�.")]
    public float maxScore = 10.0f;

    [Header("�浹 üũ")]
    [Tooltip("Pet�� ����ִ� ������ Ȯ���մϴ�.")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected private float groundCheckDistance;

    [Tooltip("�Ʒ� ������ �̳׶��� �����մϴ�.")]
    [SerializeField] protected Transform mineralUnderCheck;
    [SerializeField] protected float mineralCheckDistance;

    [Tooltip("�ٶ󺸴� ���⿡ �̳׶��� ������ ����ŭ �����մϴ�.")]
    [SerializeField] protected Transform sideMineralCheck;
    [SerializeField] protected float sideMineralCheckDistance;

    [Tooltip("���鿡 ������ �������� �����մϴ�.")]
    [SerializeField] protected Transform sideCheck;
    [SerializeField] protected float sideCheckDistance;

    [Tooltip("Pet �ڿ� �̳׶��� �ִ��� �����մϴ�.")]
    [SerializeField] protected Transform backCheck;
    [SerializeField] protected float backCheckDistance;

    [Tooltip("���� üũ�Ͽ� ������ȯ�� �����մϴ�.")]
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;

    [Header("���̾� üũ")]
    [SerializeField] protected private LayerMask whatIsGround;
    [SerializeField] protected private LayerMask whatIsWall;
    [SerializeField] protected private LayerMask WhatIsMineral;
    [SerializeField] protected private LayerMask WhatIsSideTile;

    // ���� ��ȯ �� ��ų ����
    protected int facingDir = -1;
    protected bool facingRight = true;
    private int attackLv = 1;
    private int scanLv = 1;
    private int carryLv = 1;
    private int cooltimeLv = 1;
    //

    //������Ʈ
    protected Rigidbody2D rbody;
    protected Animator anim;
    protected SpriteRenderer spr;
    private S_Mineral mineral;
    MovementController2D move_Astar;
    //

    #region anim bool
    protected bool isGrounded;
    protected bool isWallDetected;
    protected bool isMineraled;
    protected bool isSideDetected;
    protected bool isSideMineralDetected;
    protected bool isBackDetected;
    protected bool petMove;
    protected bool underMine;
    protected bool sideMine;
    protected bool petIdle;
    protected bool petFly;
    protected bool hasFlipped = false;
    protected bool isPetCooldown = false;
    private bool hardTileCheck;
    private bool repeatLabor =false;
    #endregion

    protected virtual void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        mineral = GetComponent<S_Mineral>();
        move_Astar = GetComponent<MovementController2D>();
    }

    protected virtual void Update()
    {
        CollisionChecks();
        PetAnimatorControllers();
        FlipController();

        if (!repeatLabor) 
        { 
            maxComebackHome(); 
        }      
        RestartMining();
    }

    #region Mining
    protected void RestartMining()
    {
        if (isPetCooldown)
        {
            petCooldownTimer -= Time.deltaTime;

            if (petCooldownTimer <= 0.0f)
            {
                isPetCooldown = false;
                petCooldownTimer = 100.0f;

                move_Astar.Gmc();
            }
        }
    }

    protected void maxComebackHome()
    {
        if (redjemScore + greenjemScore + bluejemScore >= maxScore)
        {
            Debug.Log("���� ������ ������ �ִ�ġ�� ������, Dome���� �����մϴ�.");
            move_Astar.Bmc();
            repeatLabor = true;
        }

    }
    #endregion


    #region Flip 
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void FlipController()
    {
        if (isWallDetected)
        {
            Debug.Log("Flip");
            Flip();
        }
        else if (isBackDetected)
        {
            if (!hasFlipped)
            {
                sideMine = true;
                underMine = false;
                petIdle = false;
                petMove = false;
                Flip();
                hasFlipped = true;
            }
        }
        else
        {
            hasFlipped = false;
        }
    }

    #endregion

    #region CollisionChecks
    protected virtual void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, new Vector2(0,0f -0.1f), groundCheckDistance, whatIsGround);
        isWallDetected = Physics2D.Raycast(wallCheck.position, Vector2.left, wallCheckDistance * -facingDir, whatIsWall);

        isMineraled = Physics2D.Raycast(mineralUnderCheck.position, Vector2.down, mineralCheckDistance, WhatIsMineral);
        isSideMineralDetected = Physics2D.Raycast(sideMineralCheck.position, new Vector2(-1.0f, 0.0f), sideMineralCheckDistance * -facingDir, WhatIsMineral);

        isBackDetected = Physics2D.Raycast(backCheck.position, Vector2.right,backCheckDistance * facingDir, WhatIsMineral);
        isSideDetected = Physics2D.Raycast(sideCheck.position, new Vector2(-0.5f, 0.0f), sideCheckDistance * -facingDir, WhatIsSideTile);

    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(sideCheck.position, new Vector3(sideCheck.position.x + sideCheckDistance * facingDir, sideCheck.position.y));
        Gizmos.DrawLine(sideMineralCheck.position, new Vector3(sideMineralCheck.position.x + sideMineralCheckDistance * facingDir, sideMineralCheck.position.y));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(mineralUnderCheck.position, new Vector3(mineralUnderCheck.position.x, mineralUnderCheck.position.y - mineralCheckDistance));

        Gizmos.color = Color.black;
        Gizmos.DrawLine(backCheck.position, new Vector3(backCheck.position.x + backCheckDistance * -facingDir, backCheck.position.y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stash"))
        {
            S_GameManager.instance.stash.redjemScore = redjemScore;
            S_GameManager.instance.stash.bluejemScore = bluejemScore;
            S_GameManager.instance.stash.greenjemScore = greenjemScore;

            redjemScore = 0;
            bluejemScore = 0;
            greenjemScore = 0;

            isPetCooldown = true;
            repeatLabor = false;
            Debug.Log("Stash�� ���� �ݳ��� �Ϸ��Ͽ����ϴ�.");
        }

       // if (collision.gameObject.CompareTag("Platform"))
    }

    #endregion

    #region Velocity
    protected void ZeroVelocity() => rbody.velocity = Vector2.zero;
    protected void MoveVelocity() => rbody.velocity = new Vector2(petSpeed * facingDir, rbody.velocity.y);

    #endregion

    #region Animaition
    private void PetAnimatorControllers()
    {
        anim.SetBool("Pet_Move", petMove);
        anim.SetBool("Pet_idle", petIdle);
        anim.SetBool("Pet_Fly", petFly);
        anim.SetBool("Under_Mine", underMine);
        anim.SetBool("Side_Mine", sideMine);
    }

    void PetUnderMine()
    {
        Collider2D groundCollider2d = Physics2D.OverlapCircle(footPos.position, 0.05f, whatIsGround);
        Collider2D mineralCollider2d = Physics2D.OverlapCircle(footPos.position, 0.05f, WhatIsMineral);

        if (mineralCollider2d != null)
        {
            mineralCollider2d.transform.GetComponent<S_Mineral>().SetDamage(petDamage);
        }
        else if (groundCollider2d != null && !hardTileCheck)
        {
            groundCollider2d.transform.GetComponent<S_MapGenerator>().MakeDot(footPos.position);
        }
    }

    void PetSideMine()
    {
        Collider2D groundCollider2d = Physics2D.OverlapCircle(toothPos.position, 0.01f, whatIsGround);
        Collider2D mineralCollider2d = Physics2D.OverlapCircle(toothPos.position, 0.01f, WhatIsMineral);

        if (mineralCollider2d != null)
        {
            mineralCollider2d.transform.GetComponent<S_Mineral>().SetDamage(petDamage);
        }
        else if (groundCollider2d != null && !hardTileCheck)
        {
            groundCollider2d.transform.GetComponent<S_MapGenerator>().MakeDot(toothPos.position);
        }
    }
    #endregion

    #region Pet Skill
    protected void PetDamageLv2()
    {
        if (attackLv == 1) 
        {
            petDamage += 5.0f;
       
            attackLv = 2;
        }
    }

    protected void PetDamageLv3()
    {
        if (attackLv == 2 ) 
        {
            petDamage += 10.0f;

            attackLv = 3;
        }
    }

    protected void PetCarryLv2()
    {
        if (carryLv == 1)
        {
            maxScore = 20;
            carryLv = 2;
        }
    }

    protected void PetCarryLv3()
    {
        if (carryLv == 2)
        {
            maxScore = 30;
            carryLv = 3;
        }
    }

    protected void PetScanLv2()
    {
        if (scanLv == 1)
        {
            sideMineralCheckDistance++;
            scanLv = 2;
        }
    }

    protected void PetScanLv3()
    {
        if (scanLv == 2)
        {
            sideMineralCheckDistance++;
            scanLv = 3;
        }
    }

    protected void PetCoolTimeUpgrade()
    {
        if (cooltimeLv == 1 || scanLv == 2 || carryLv == 2 || attackLv == 2)
        {
            cooltimeLv = 2;
            petCooldownTimer = petCooldownTimerUpgrade;
        }
    }

    protected void DoublePet()
    {
        if (cooltimeLv == 2)
        {
            
        }
    }

    #endregion

}
