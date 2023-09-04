using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] public float Atk;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<M_Base>().Damage(Atk);
            Debug.Log("데미지가" + Atk + "만큼 달고있어용");
        }
    }
}
