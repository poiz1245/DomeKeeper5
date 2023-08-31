using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Pet_SkillManager : MonoBehaviour
{
    public static Pet_SkillManager instance;
    public Pet_Skill[] skills;
    public Pet_SkillButton[] skillButtons;
    public Pet_Skill activateSkill;

    //��ų�г�
    public GameObject SkillPanel;

    //�����г�
    public GameObject scoreText;
    public static int totalScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SkillPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab)) 
        {
            SkillPanel.SetActive(true);
            Debug.Log("�г� On");
        }
        else
        {
            SkillPanel.SetActive(false);
            Debug.Log("�г� Off");
        }
    }


}
