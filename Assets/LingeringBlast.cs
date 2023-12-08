using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingeringBlast : MonoBehaviour
{
    int time = 0;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        time++;
        if (time == 3)
        {
            time = 0;
            try
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(2, 1);
            }
            catch
            {
                //pass
            }
        }
    }

    private void FixedUpdate()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - 0.005f);
    }
}
