using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
 
    public GameObject LazerEnd;
    void Awake()
    {
     
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dome"))
        {
         
            Debug.Log("���浥�����Դ���");
            
           
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Instantiate(LazerEnd);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
      
    }
}
