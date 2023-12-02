using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    public int slowDuration { get; set; }
    private float slowIntensity;
    public bool isBurned { get; set; }

    private void Start()
    {
        target = Levelmanager.main.path[pathIndex];
        slowDuration = 0;
    }

    private void Update()
    {
        if(Vector2.Distance(target.position,transform.position) <= 0.1f) {
            pathIndex++;

            if (pathIndex == Levelmanager.main.path.Length)
            {
                enermySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = Levelmanager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        if (slowDuration > 0)
        {
            slowDuration--;
            direction *= slowIntensity;
            if (isBurned && slowDuration % 2 == 0) {
                GetComponent<Health>().TakeDamage(1, 2);
            }
        }
        else
        {
            isBurned = false;
        }

        rb.velocity = direction * moveSpeed;
    }

    public int getPathIndex()
    {
        return pathIndex;
    }

    public Transform getTarget()
    {
        return target;
    }

    public void Slow(int slowDur, float slowIntens)
    {
        if (slowDur > slowDuration) slowDuration = slowDur;
        if (slowIntens > slowIntensity) slowIntensity = slowIntens;
    }
}
