using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfo : MonoBehaviour
{
    public int id;
    public bool isPurchased;
    public float cost;
    public Text Destext;

    public void Awake()
    {
        Destext = GetComponent<Text>();
    }
    public void BtnOnClick()
    { 
        if(id == 1) 
        {
           
            Destext.text = "�������� ������ ���������ϴ�.";
        }
        if (id == 2)
        {
            Destext.text = "��밡���� ����Ÿ���� �ϳ� �߰��մϴ�.";
        }
        if (id == 3)
        {
            Destext.text = "�� �̻� ��ž�� ������ �� ������ �ڵ����� �����̸� �����մϴ�.";
        }
    }
}
