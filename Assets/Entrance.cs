using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public GameObject destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemy(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.GetComponent<EnemyScript>().setDestination(destination);
        newEnemy.transform.up = Vector3.Normalize(destination.transform.position - newEnemy.transform.position);
    }
}
