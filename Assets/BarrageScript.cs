using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageScript : MonoBehaviour
{
    public int damage; //damage per shot
    public int fireDelay; //fixedUpdate frames before next shot
    public float range;
    int curDelay;

    // Start is called before the first frame update
    void Start()
    {
        curDelay = fireDelay/2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (curDelay == fireDelay)
        {
            Aim();
        } else
        {
            curDelay++;
        }
    }

    void Aim()
    {
        Collider2D[] results = new Collider2D[100];
        int numObjects = Physics2D.OverlapCircle(transform.position, range, new ContactFilter2D().NoFilter(), results);
        Debug.Log("Found " + numObjects + " objects in range.");
        List<enemyMovement> enemies = new List<enemyMovement>();
        int greatestIndex = 0;
        foreach (Collider2D result in results)
        {
            if (result != null)
            {
                enemyMovement enemy = result.gameObject.GetComponent<enemyMovement>();
                if (enemy != null)
                {
                    int curIndex = enemy.getPathIndex();
                    Debug.Log("Enemy sighted: " + enemy.name + " at path index " + curIndex);
                    if (curIndex > greatestIndex)
                    {
                        Debug.Log("New highest path index found: " + curIndex +
                            ". Clearing " + enemies.Count + " enemies with index " + greatestIndex + ".");
                        enemies = new List<enemyMovement>();
                        enemies.Add(enemy);
                        greatestIndex = curIndex;
                    }
                    else if (curIndex == greatestIndex)
                    {
                        enemies.Add(enemy);
                    }
                    //if it's lesser, it's not the target, don't bother with it, do nothing
                }
            }
        }

        if (enemies.Count == 0)
        {
            Debug.Log("No enemies in range");
            return; //Nothing to fire at
        }

        //Going ahead with firing, set delay
        curDelay = 0;
        Debug.Log(enemies.Count + " enemies with highest path index (" + greatestIndex + " in range.");

        float leastDistance = Mathf.Infinity;
        enemyMovement target = null;
        foreach (enemyMovement enemy in enemies)
        {
            float curDistance = Vector3.Distance(enemy.transform.position, enemy.getTarget().position);
            if (curDistance < leastDistance)
            {
                leastDistance = curDistance;
                target = enemy;
            }
            else if (curDistance == leastDistance)
            {
                //TODO: Break ties based on least health once health exists.
            }
        }

        Fire(target);
    }

    void Fire(enemyMovement target)
    {

        DrawLine(transform.position, target.transform.position, Color.red);

        Health targetHealth = target.gameObject.GetComponent<Health>();
        targetHealth.TakeDamage(damage, 0);
        //hardcoded damage type since every tower type needs its own fire function anyways
        Debug.Log(targetHealth.damageResistances[0]);
        targetHealth.damageResistances[0] -= 5;
        targetHealth.damageResistances[1] -= 5;
        targetHealth.damageResistances[2] -= 5;
    }

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //lr.material = new Material(Shader.Find("Particles / Alpha Blended Premultiply"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}
