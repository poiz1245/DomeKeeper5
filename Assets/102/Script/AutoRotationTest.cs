using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotationTest : MonoBehaviour
{
    public float angularSpeed = 30.0f; // �¿� �ڵ� ȸ�� �ӵ� (��/��)
    public float leftLockAngle = -45.0f; // ���� ȸ�� ���� ����
    public float rightLockAngle = 45.0f; // ���� ȸ�� ���� ����

    void Update()
    {
        AutoRotate();
    }

    void AutoRotate()
    {
        float rotationAmount = angularSpeed * Time.deltaTime;

        if (transform.rotation.eulerAngles.z < leftLockAngle)
        {
            rotationAmount = Mathf.Abs(rotationAmount);
        }
        else if (transform.rotation.eulerAngles.z > rightLockAngle)
        {
            rotationAmount = -Mathf.Abs(rotationAmount);
        }

        transform.Rotate(0, 0, rotationAmount);
    }
}
