using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
using UnityEngine.SocialPlatforms.Impl;

public class PetController : PetEntity
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        OnMine();
    }

    public void OnMine()
    {

        #region Mine
        if (isGrounded)
        {
            MoveVelocity();
            petFly = false;
            underMine = false;
            sideMine = true;
        }

        if (isMineraled)
        {
            ZeroVelocity();
            petFly = false;
            sideMine = false;
            underMine = true;
        }
        if (!isGrounded)
        {
            underMine = false;
            sideMine = false;
            petFly = true;
        }

        if (isSideMineralDetected)
        {
            MoveVelocity();
            petFly = false;
            underMine = false;
            sideMine = true;
        }

        if (!isSideMineralDetected && isGrounded)
        {
            ZeroVelocity();
            petFly = false;
            sideMine = false;
            underMine = true;
        }

        if (!sideCheck && isGrounded)
        {
            ZeroVelocity();
            petFly = false;
            sideMine = false;
            underMine = true;
        }

        #endregion
    }
}