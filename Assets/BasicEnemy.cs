using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void die()
    {
        //if we bother to code a death animation it goes here

        Debug.Log("Died");

        Destroy(gameObject);
    }
}
