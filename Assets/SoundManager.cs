using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip Lazer;
    public AudioClip LoopingBackGround;
    public AudioClip LoopingSwordMove;
    public AudioClip LazerHit;
    public AudioClip LazerMove;
    public AudioClip SwordMove;
    public AudioClip SwordHit;
    public AudioClip Skillpc;
    public AudioClip Playpc;
    public AudioClip SubTowerAtk;
    public AudioClip FireTowerAtk;
    public AudioClip StunTowerAtk;
    public AudioClip AutoTowerAtk;
    public AudioClip digSound;
    public AudioClip groundCrack;
    public AudioClip mineralCrack;
    public AudioClip computerOn;
    public AudioClip computerOff;
    public AudioClip teleportSound;
    public AudioClip domeIn;
    public AudioClip domeOut;
    public AudioClip skillUp;
    public AudioClip skillOpen;
    public AudioClip jemSave;



    AudioSource myAudio; //AudioSorce ������Ʈ�� ������ ����ϴ�.
    void Awake() //Start���ٵ� ����, ��ü�� �����ɶ� ȣ��˴ϴ�
    {
        if (SoundManager.instance == null) //incetance�� ����ִ��� �˻��մϴ�.
        {
            SoundManager.instance = this; //�ڱ��ڽ��� ����ϴ�.
        }
    }
    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource ������Ʈ�� ������ ����ϴ�.

    }
    public void PlayLazer()
    {
        myAudio.PlayOneShot(Lazer); //soundExplosion�� ����մϴ�.
    }
    public void PlayLazerHit()
    {
        myAudio.PlayOneShot(LazerHit); //soundExplosion�� ����մϴ�.
    }
    public void PlayLazerMove()
    {
        myAudio.PlayOneShot(LazerMove); //soundExplosion�� ����մϴ�.
    }
  
    public void PlaySwordHit(float volume)
    {
        myAudio.clip = SwordHit; // �Ҹ� Ŭ�� ����
        myAudio.volume = volume; // ���ϴ� ���� ����
        myAudio.PlayOneShot(SwordHit); // �Ҹ� ���
    }
    public void PlayPc()
    {
        myAudio.PlayOneShot(Playpc); //soundExplosion�� ����մϴ�.
    }
    public void PlaySkillPc()
    {
        myAudio.PlayOneShot(Skillpc); //soundExplosion�� ����մϴ�.
    }
    public void PlaySubTower()
    {
        myAudio.PlayOneShot(SubTowerAtk); //soundExplosion�� ����մϴ�.
    }
    public void PlayStunTower()
    {
        myAudio.PlayOneShot(StunTowerAtk); //soundExplosion�� ����մϴ�.
    }
    public void PlayFireTower()
    {
        myAudio.PlayOneShot(FireTowerAtk); //soundExplosion�� ����մϴ�.
    }
    public void PlayAutoTower()
    {
        myAudio.PlayOneShot(AutoTowerAtk); //soundExplosion�� ����մϴ�.
    }
    public void PlayGroundCrack()
    {
        myAudio.PlayOneShot(groundCrack);
    }
    public void PlayMineralCrack()
    {
        myAudio.PlayOneShot(mineralCrack);

    }
    public void PlayComputerOn()
    {
        myAudio.PlayOneShot(computerOn);

    }
    public void PlayComputerOff()
    {
        myAudio.PlayOneShot(computerOff);

    }
    public void PlayUseTeleport()
    {
        myAudio.PlayOneShot(teleportSound);

    }
    public void PlayDomeIn()
    {
        myAudio.PlayOneShot(domeIn);

    }
    public void PlayDomeOut()
    {
        myAudio.PlayOneShot(domeOut);

    }
    public void PlaySkillUp()
    {
        myAudio.PlayOneShot(skillUp);

    }
    public void PlaySkillOpen()
    {
        myAudio.PlayOneShot(skillOpen);

    }
    public void PlayDigSound()
    {
        myAudio.PlayOneShot(digSound);

    }
    public void PlayJemSave()
    {
        myAudio.PlayOneShot(jemSave);

    }



    // ���� ��� ���θ� ��Ÿ���� ����
    private bool isLoopingBack = false;
    private bool isLoopingSwordMove = false;

    void Update()
    {
  
        if (isLoopingBack && !myAudio.isPlaying)
        {
            myAudio.clip = LoopingBackGround;
            myAudio.loop = true;
            myAudio.Play();
        }

        if(isLoopingSwordMove && !myAudio.isPlaying)
        {
            myAudio.clip = LoopingSwordMove;
            myAudio.loop = true;
            myAudio.Play();
        }
    }
    

    public void StartLooping()
    {
        isLoopingBack = true;
        myAudio.clip = LoopingBackGround;
        myAudio.loop = true;
        myAudio.Play();
    }
    public void StopLooping()
    {
        isLoopingBack = false;
        myAudio.Stop();
    }

    public void StartLoopingSwordMove()
    {
        isLoopingSwordMove = true;
        myAudio.clip = LoopingSwordMove;
        myAudio.loop = true;
        myAudio.Play();
    }

}

