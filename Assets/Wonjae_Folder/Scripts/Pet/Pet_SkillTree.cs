using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_SkillTree : MonoBehaviour
{
    [SerializeField]
    private Pet_Skill[] skills;

    private void Start()
    {
        ResetSkills();
    }

    private void ResetSkills()
    {
        foreach (Pet_Skill skill in skills)
        {
            skill.Lock();
        }
    }

}
