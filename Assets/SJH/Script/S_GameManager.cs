using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class S_GameManager : MonoBehaviour
{
    public static S_GameManager instance;

    public WJ_Player player;
    public PetController pet;
    public float GameTime = 0;

    void Start()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        GameTime = Time.time;
    }
}
