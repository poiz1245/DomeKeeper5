using UnityEngine;

public class Dome : MonoBehaviour
{
    #region
    [Header("��")]

    [SerializeField] public float MaxHp;
    [SerializeField] public float CurHp;
    [SerializeField] public float Def;
    [SerializeField] float trueatk;

    public GameObject Damaged;
    public GameObject DestroyDome;
    [Header("�� ����")]
    [SerializeField] bool isShield = false;
    SpriteRenderer SI;
    SpriteRenderer Dd;
    public GameObject ShieldIg;
    [SerializeField] public float Shield;
    [SerializeField] public float MaxShield;
    [SerializeField] float RespawnTime;
    [SerializeField] float CoolTimer;

    [Header("��")]
    [SerializeField] float Atk;

    #endregion

    private void Start()
    {
        SI = ShieldIg.GetComponent<SpriteRenderer>();
        Dd = Damaged.GetComponent<SpriteRenderer>();
        CurHp = MaxHp ;
        CoolTimer = 29f;
    }

    private void Update()
    {
        if (SkillTreeManager.Instance.isShield == true)
        {
            if (!isShield)
            {
                CoolTimer += Time.deltaTime;
            }
            if (CoolTimer > RespawnTime)
            {

                Shield = MaxShield;
                isShield = true;
                SI.enabled = true;
                CoolTimer = 0f;

            }

        }
    }

    public void SetHeal(float heal)
    {
        CurHp += heal;
        if (CurHp > MaxHp)
        {
            CurHp = MaxHp;
        }

    }
    public void SetDamage(float atk)
    {
        if (!isShield)
        {
            trueatk = atk - Def;
            if (trueatk <= 0)
            {
                trueatk = 0;
            }

            CurHp -= trueatk;

            if (CurHp < MaxHp / 2)
            {
                Dd.enabled = true;
            }
            else

                Dd.enabled = false;
            if (CurHp < 0)
            {
                DestroyDome.SetActive(true);
                //��� ó���Ұ��� �� ? 
            }
        }
        else if (isShield)
        {

            trueatk = atk - Def;
            if (trueatk <= 0)
            {
                trueatk = 0;
            }
            Shield -= trueatk;
            if (Shield < 0)
            {
                Shield = 0f;
                SI.enabled = false;
                isShield = false;
            }
        }
    }


}
