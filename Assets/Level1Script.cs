using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Script : MonoBehaviour
{
     (string, int, float)[][] waves = new (string, int, float)[][]
     {
         new (string, int, float)[]
         {
            ("Basic", 0, 1),
            ("Basic", 0, 3),
            ("Basic", 0, 0),
            ("Basic", 0, 0),
            ("Basic", 0, 0)
         },
         new (string, int, float)[]
         {
            ("Basic", 0, 0),
            ("Basic", 0, 0),
            ("Basic", 0, 0),
            ("Basic", 0, 3),
            ("Basic", 0, 0)
         }
     };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getWave(int wave)
    {
        gameObject.GetComponentInParent<WaveManagerScript>().recieveWave(waves[wave]);
    }
}
