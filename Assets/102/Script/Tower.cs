using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
    { 
    #region 
    [Header("Ÿ�� ������")]
    [SerializeField] protected Transform rotationCenter;
    [SerializeField] protected float rotationRadius, angularSpeed;
    [SerializeField] protected float leftLockAngle;
    [SerializeField] protected float rightLockAngle;
    [SerializeField] protected float rote;
    protected float posX, posY, angle = 0f;
    #endregion
    }
