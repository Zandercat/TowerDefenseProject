using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProjectileScript : MonoBehaviour
{
    public int speed;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health enemy = collision.gameObject.GetComponent<Health>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage, 1);
            Destroy(gameObject);
        }
    }

}
