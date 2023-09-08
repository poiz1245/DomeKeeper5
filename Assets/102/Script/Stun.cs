using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
   
    [SerializeField] public float stunTime;

    public float Speed = 5f;

    public float Atk;
    private GameObject target; // ���� ���� ���� ��
    private float chaseRange = 50f; // ���� ����
    private List<GameObject> availableTargets = new List<GameObject>(); // �̵� ������ �� ���
    public M_Base monsterBase;

    private void Start()
    {
        FindAvailableTargets();
        SetNextTarget();
        //monsterBase.ChangeStunTime(100);
        if(target != null) { 
        SoundManager.instance.PlaySubTower();
        }
    }

    public float GetsStunTime()
    {
        return stunTime;
    }

    private void Update()
    {
        stunTime = M_GameManager.instance.stunTime;
        if (target != null)
        {

            // Ÿ�� ���� ���
            Vector3 dir = (target.transform.position - transform.position).normalized;
            // �̵�
            transform.Translate(dir * Speed * Time.deltaTime, Space.World);

            // ���� Ÿ�ٰ��� �Ÿ��� ���� ���� ���� �ִٸ� Ÿ���� ����
            if (Vector3.Distance(transform.position, target.transform.position) < 0.5f)
            {
                target.GetComponent<M_Base>().Damage2(Atk);
                Destroy(gameObject);
            }
        }
        else
        {
            // Ÿ���� ���� ��� �Ѿ� �ı�
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<M_Base>().Damage2(Atk);
            Destroy(gameObject);
        }
    }

    // �̵� ������ �� ����� ã���ϴ�.
    private void FindAvailableTargets()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

        foreach (GameObject monster in monsters)
        {
            float distance = Vector3.Distance(transform.position, monster.transform.position);
            if (distance < chaseRange)
            {
                availableTargets.Add(monster);
            }
        }
    }

    // ���� Ÿ���� �����մϴ�.
    private void SetNextTarget()
    {
        if (availableTargets.Count > 0)
        {
            // �̵� ������ �� �߿��� ���� ����� ���� ����
            float closestDistance = Mathf.Infinity;
            foreach (GameObject monster in availableTargets)
            {
                float distance = Vector3.Distance(transform.position, monster.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    target = monster;
                }
            }

            // ���õ� ���� ��Ͽ��� ����
            availableTargets.Remove(target);
        }
        else
        {
            // �̵� ������ ���� ���� ���, �Ѿ��� �ı�
            Destroy(gameObject);
        }
    }
}