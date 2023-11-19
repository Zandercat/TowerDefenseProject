using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject destination;
    public float movementSpeed = 0.5f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetDirection = destination.transform.position - transform.position;
        float angle = Vector2.SignedAngle(transform.up, targetDirection);
        if (Mathf.Abs(angle) < 1)
        {
            transform.up = targetDirection.normalized;
            rb.velocity = transform.up * movementSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
            if (Mathf.Abs(angle) > movementSpeed * 5) angle = movementSpeed * 2.5f * Mathf.Sign(angle);
            transform.Rotate(0, 0, angle);
        }
    }

    public void setDestination(GameObject newDest)
    {
        destination = newDest;
    }
}
