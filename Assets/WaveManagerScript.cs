using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerScript : MonoBehaviour
{
    public GameObject[] entrances;
    int waveCountdown = -1;
    (string, int, float)[] wave;
    int spawnCount = 0;

    public GameObject[] enemyCatalogue;
    public List<string> enemyIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void recieveWave((string, int, float)[] newWave)
    {
        wave = newWave;
    }

    void betweenWaves()
    {
        //TODO: activate "call next wave" button 
        if(waveCountdown > 0)
        {
            //TODO: visibly count down until the next wave

            waveCountdown--;
            
        }
        else if(waveCountdown == 0)
        {
            waveCountdown = -1;
            
        }
    }

    void nextEnemy()
    {
        (string, int, float) curSpawn = wave[spawnCount];
        GameObject curEntrance = entrances[curSpawn.Item2];
        GameObject curEnemy = Instantiate(enemyCatalogue[enemyIndex.IndexOf(curSpawn.Item1)], curEntrance.transform);
        curEnemy.GetComponent<EnemyScript>().setDestination(curEntrance.GetComponent<Entrance>().destination);
        curEnemy.transform.up = Vector3.Normalize(curEntrance.GetComponent<Entrance>().destination.transform.position - curEnemy.transform.position);

        spawnCount++;

        Invoke("nextEnemy", curSpawn.Item3);
    }
}
