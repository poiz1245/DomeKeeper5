using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_SkillUnLock : MonoBehaviour
{
    public Button button;
    public GameObject UnlockImage;
    [SerializeField] bool useCheck = false;

    enum SkillName
    {
        light,
        teleport,
    }

    [SerializeField] SkillName skillName;

    private void Start()
    {

    }
    private void Update()
    {
        if (useCheck)
        {
            if (skillName == SkillName.light)
                gameObject.GetComponentInChildren<Slider>().value += (1 / S_GameManager.instance.player.lightCoolTime) * Time.deltaTime;
            else if (skillName == SkillName.teleport)
                gameObject.GetComponentInChildren<Slider>().value += (1 / S_GameManager.instance.player.teleportCoolTime) * Time.deltaTime;

        }

    }
    public void Unlock()
    {
        UnlockImage.SetActive(false);
        gameObject.GetComponentInChildren<Slider>().value = 100;
        useCheck = true;
    }
}
