using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int HP;

    public List<string> conditionImmunities;
    public int[] damageResistances; //Element 0 is damage from DPS. Element 1 is damage from AoE. Element 2 is damage from Support.
    //these are percent resistances. 0 is no resistance. 100 is immunity. >100 will cause healing from damage.

    int slowTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage, int damageType) //
    {
        damage -= damage * damageResistances[damageType] / 100;
        HP -= damage;
        if (HP <= 0)
        {
            gameObject.SendMessage("die");
        }
    }



}
