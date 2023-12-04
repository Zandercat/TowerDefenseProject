using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelmanager : MonoBehaviour {

    public static Levelmanager main;

    public int lives;

    public Transform startPoint;
    public Transform[] path;

    private void Awake()
    {
        main = this;
    }

    public void loseLife()
    {
        lives--;
        if (lives == 0)
        {
            //lose the game
        }
    }
}
