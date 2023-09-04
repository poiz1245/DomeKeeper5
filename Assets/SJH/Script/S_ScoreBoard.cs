using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ScoreBoard : MonoBehaviour
{
    [SerializeField] GameObject scoreBoard;
    [SerializeField] GameObject map;
    float count =5;
    void Update()
    {
        count -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.I))
        {
            scoreBoard.SetActive(true);
            count = 5;
           
        }
        if (count <= 0)
        {
            scoreBoard.SetActive(false);
        }

        if(Input.GetKey(KeyCode.Tab))
        {
            map.SetActive(true);
        }
        else
        {
            map.SetActive(false);
        }
    }
}
