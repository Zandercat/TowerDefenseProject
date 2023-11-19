using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScript enemyScript = collision.GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            Destroy(collision.gameObject);
            Debug.Log("An enemy reached the exit! You would have lost 1 life.");
        }
    }
}
