using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; // Ǯ���� ������
    public int poolSize = 10; // Ǯ ũ��

    private Queue<GameObject> objectPool = new Queue<GameObject>();

    private void Start()
    {
        InitializePool();
    }

    // Ǯ �ʱ�ȭ
    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    // ������Ʈ�� Ǯ���� ��������
    public GameObject GetObjectFromPool(Vector3 position, Quaternion rotation)
    {
        if (objectPool.Count > 0)
        {
            GameObject obj = objectPool.Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj;
        }
        else
        {
            // Ǯ�� ������� ��� �߰��� ����
            GameObject obj = Instantiate(prefab, position, rotation);
            return obj;
        }
    }

    // ������Ʈ�� Ǯ�� ��ȯ�ϱ�
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }
}