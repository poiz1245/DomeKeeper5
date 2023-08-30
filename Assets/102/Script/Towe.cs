using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towe : MonoBehaviour
{
    [SerializeField] private Transform domeCenter;
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform laserSpawnPoint;

    private bool isRotating = false;

    private void Update()
    {
        HandleRotation();
        HandleAttack();
    }

    private void HandleRotation()
    {
        // �� ȸ�� ó��
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            domeCenter.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            domeCenter.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
    }

    private void HandleAttack()
    {
        // ȸ�� �߿� ���� �������� üũ
        if (isRotating)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireLaser();
            }
        }
    }

    private void FireLaser()
    {
        // ������ �߻�
        GameObject laser = Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
        Destroy(laser, 2f); // ���� �ð� �Ŀ� ������ �ı�

        // ȸ�� �߿��� �������� �߻��� �� ������ ó��
        isRotating = false;
        Invoke(nameof(EnableAttack), 1f); // 1�� �Ŀ� �ٽ� ���� �����ϰ� ����
    }

    private void EnableAttack()
    {
        isRotating = true;
    }
}