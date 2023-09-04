using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class M_CameraScript : MonoBehaviour
{
    public Camera cam;
    public GameObject virCamera;
    float t;
    float x;
    float size;

    int d;
    // Start is called before the first frame update
    void Start()
    {
        x = cam.orthographicSize;
        size = 12.94965f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            d = 1;
            t = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            d = 0;
            t = 0;
        }


        if (d == 1)
        {
            virCamera.SetActive(false);
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, -10), t / 10);
            cam.orthographicSize = Mathf.Lerp(x, size, t);
        }
        else if (d == 0)
        {
            t += Time.deltaTime;
            virCamera.SetActive(true);
            cam.orthographicSize = Mathf.Lerp(size, x, t);
        }
        

        
        
    }
}
