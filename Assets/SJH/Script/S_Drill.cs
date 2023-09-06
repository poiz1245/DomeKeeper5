using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class S_Drill : MonoBehaviour
{
    public float damage;
    [SerializeField] LayerMask wahtisGround;
    [SerializeField] LayerMask wahtisMIneral;
    [SerializeField] Transform drillPos;

    bool hardTileCheck;

    void Dig()
    {
        Collider2D groundCollider2d = Physics2D.OverlapCircle(drillPos.position, 0.01f, wahtisGround);
        Collider2D mineralCollider2d = Physics2D.OverlapCircle(drillPos.position, 0.01f, wahtisMIneral);

        if (mineralCollider2d != null)
        {
            mineralCollider2d.transform.GetComponent<S_Mineral>().SetDamage(damage);
        }
        else if (groundCollider2d != null && hardTileCheck == false)
        {
            groundCollider2d.transform.GetComponent<S_MapGenerator>().MakeDot(drillPos.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HardTile"))
        {
            hardTileCheck = true;
        }
        else
            hardTileCheck = false;
    }




}
