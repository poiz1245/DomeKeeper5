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
    public void PlaySwordMove()
    {
        myAudio.PlayOneShot(SwordMove); //soundExplosion�� ����մϴ�.
    }
    public void PlaySwordHit()
    {
        myAudio.PlayOneShot(SwordHit); //soundExplosion�� ����մϴ�.
    }
    public void PlayPc()
    {
        myAudio.PlayOneShot(Playpc); //soundExplosion�� ����մϴ�.
    }
    public void PlaySkillPc()
    {
        myAudio.PlayOneShot(Skillpc); //soundExplosion�� ����մϴ�.
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

