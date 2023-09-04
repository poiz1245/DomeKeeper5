using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_VirtualCamera : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    [SerializeField] float domeOrthoSize = 13f;
    [SerializeField] float mineOrthoSize = 6f;
    [SerializeField] Transform domeViewPoint;
    [SerializeField] float zoomSpeed = 1f;

    void Update()
    {
        float currentSize = virtualCamera.m_Lens.OrthographicSize;

        if (S_GameManager.instance.player.transform.position.y >= -15f)
        {
            currentSize += zoomSpeed * Time.deltaTime;
            virtualCamera.m_Follow = domeViewPoint;
        }
        else if (S_GameManager.instance.player.transform.position.y < -15f)
        {
            currentSize -= zoomSpeed * Time.deltaTime;
            virtualCamera.m_Follow = S_GameManager.instance.player.transform;
        }

        currentSize = Mathf.Clamp(currentSize, mineOrthoSize, domeOrthoSize);

        virtualCamera.m_Lens.OrthographicSize = currentSize;
    }
}
