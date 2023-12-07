using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelmanager : MonoBehaviour {

    public static Levelmanager main;

    public int lives = 10;

    public Transform startPoint;
    public Transform[] path;

    public HealthBarScript healthBar;

    private void Awake()
    {
        main = this;
        healthBar.SetMaxHealth(lives);
    }

    public void loseLife()
    {
        lives--;

        healthBar.SetHealth(lives);

        if (lives == 0)
        {
            //lose the game
        }
    }
}
