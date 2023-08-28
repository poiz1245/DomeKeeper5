using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class S_Mineral : MonoBehaviour
{
    [SerializeField] LayerMask wahtisGround;
    Collider2D groundCollider2d;
    public float Hp;

    private void Start()
    {

    }
    void Update()
    {

        if (Hp <= 0)
        {
            groundCollider2d = Physics2D.OverlapCircle(transform.position, 1f, wahtisGround);
            groundCollider2d.transform.GetComponent<S_MapGenerator>().MakeDot(transform.position);

            Destroy(gameObject);
        }
    }
    public void SetDamage(float damage)
    {
        Hp -= damage;
    }

}
