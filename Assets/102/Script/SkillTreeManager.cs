using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance;

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
    #endregion
    #region
    [Header("��ũ3")]
    [SerializeField] public bool isTech3 = false;
    #endregion
    private void Awake()
    {
        Instance = this; // ��ų Ʈ�� �Ŵ����� �ν��Ͻ��� �����մϴ�.
    }
    private void Update()
    {
        SelectTech1();
        SelectTech2();
        SelectTech3();

    }


    void SelectTech1()
    { 
        if(isTech1) 
        {
            isTech2 = false;
            isTech3 = false;
        }
    }
    void SelectTech2()
    {
        if (isTech2)
        {
            isTech1 = false;
            isTech3 = false;
        }
    }
    void SelectTech3()
    {
        if (isTech3)
        {
            isTech1 = false;
            isTech2 = false;
        }
    }
}
