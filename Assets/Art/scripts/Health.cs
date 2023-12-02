using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    public int hitPoints = 2;
    public int[] damageResistances = new int[3]; //Element 0 is damage from DPS. Element 1 is damage from AoE. Element 2 is damage from Support.
    //these are percent resistances. 0 is no resistance. 100 is immunity. >100 will cause healing from damage.

    public void TakeDamage(int dmg, int dmgType)
    {
        int newDmg = dmg * (100 - damageResistances[dmgType]) / 100; //integer division, round down to final hp number
        hitPoints -= newDmg;

        if(hitPoints <= 0)
        {
            enermySpawner.onEnemyDestroy.Invoke();
            Destroy(gameObject);
        }
    }

}
