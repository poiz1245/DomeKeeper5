using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance;

    #region
    public int id;
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



    #endregion
    #region
    [Header("��ũ3")]
    [SerializeField] public bool isTech3 = false;
    #endregion
    private void Awake()
    {
        Instance = this; // ��ų Ʈ�� �Ŵ����� �ν��Ͻ��� �����մϴ�.
    }
    void Start()
    {
       
    }
    private void Update()
    {
      
        SetActive();

    }

    void SetActive()
    {
        if (isStunTower == true)
        {
            StunTower.SetActive(true);
        }
        if (isFireTower == true)
        {
            FireTower.SetActive(true);
        }
    }
    void AttackUp()
    {
     
    }
    
}
