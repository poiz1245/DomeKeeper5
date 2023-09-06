using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : StunEntity
{
  
    private GameObject target; // ���� ���� ���� ��
    private float chaseRange = 50f; // ���� ����
    private List<GameObject> availableTargets = new List<GameObject>(); // �̵� ������ �� ���

    private void Start()
    {
        
    }
    private void Update()
    {
        transform.Translate(0,Speed * Time.deltaTime , 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<M_Base>().Damage(Atk);
            Debug.Log("���ϵɰž�");
            Destroy(gameObject);
        }
    }

}
