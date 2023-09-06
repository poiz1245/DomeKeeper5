using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance;
    private DefalutTower dt;
    private Dome dm;
    public int isAtkUp;
    public int isDefUp;
    #region
    [Header("��ũ1")]
    [SerializeField] public bool isTech1 = false;
    [SerializeField] public bool isPenetrate = false;
    [SerializeField] public bool isCharge = false;
    [SerializeField] public bool isPenetrateUpgrade1 = false;
    [SerializeField] public bool isPenetrateUpgrade2 = false;
    [SerializeField] public bool isChargeDelayless = false;
    [SerializeField] public bool isChargeTimeLess = false;
  

    #endregion
    #region
    [Header("��ũ2")]
    [SerializeField] public bool isTech2 = false;
    [SerializeField] public bool isFireTower = false;
    [SerializeField] public bool isStunTower = false;
    [SerializeField] public GameObject StunTower;
    [SerializeField] public GameObject FireTower;
    [SerializeField] public GameObject SubTower;




    #endregion
    #region
    [Header("��ũ3")]
    [SerializeField] public bool isTech3 = false;
    [SerializeField] public GameObject SwordTower;
    [SerializeField] public GameObject AutoTower;
    [SerializeField] public GameObject DomeShield;
    [SerializeField] public bool isShield;

    #endregion
    private void Awake()
    {
        Instance = this; // ��ų Ʈ�� �Ŵ����� �ν��Ͻ��� �����մϴ�.
    }
    void Start()
    {
        if (!dt)
        {
            dt = GetComponent<DefalutTower>();
        }
        if(!dm)
        {
            dm = GetComponent<Dome>();
        } 
    }
    private void Update()
    {
        EquipSubTower();
    }

    public void AttackUp()
    {
        if (isAtkUp < 5)
        {
            dt.Atk += 2;
            isAtkUp += 1;
        }
    }
    public void DefUp()
    {
        if (isDefUp < 5)
        {
            dm.Def += 2;
            isDefUp += 1;
        }
    }
    public void Tech1Active() 
    {
        isTech1 = true;
    }
    public void Tech2Active()
    {
        isTech2 = true;
    }
    public void Tech3Active()
    {
        isTech3 = true;
    }

    public void EquipSubTower()
    { 
        if(isTech2 == true) 
        {
            SubTower.SetActive(true);
        }
    }

    public void SCreateAutoTower()
    {
        if (isTech3 == true)
        {
            AutoTower.SetActive(true);
        }
    }
    public void CreateShield()
    {
        isShield = true;
        DomeShield.SetActive(true);
    }
    public void CreateSword()
    {
        SwordTower.SetActive(true);
    }

}
