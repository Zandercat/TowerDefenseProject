using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelmanager : MonoBehaviour {

    public static Levelmanager main;

    public Transform startPoint;
    public Transform[] path;

    private void Awake()
    {
        main = this;
    }

}
