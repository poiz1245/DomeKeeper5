using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dome : MonoBehaviour
{
    #region
    [Header("��")]
    [SerializeField] float Hp;
    [SerializeField] float Def;

    #endregion


    

    void SetDamage(int atk)
    {
        Hp -= atk;
        if (Hp < 0)
        { 
            //��� ó���Ұ��� �� ? 
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
