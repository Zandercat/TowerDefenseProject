using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class enermySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 7;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 8f;
    [SerializeField] private float diffcultyFactor = 0.6f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy= new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private int waveCountdown;

    private UIScript uiScript;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }
    private void Start()
    {
        uiScript = GameObject.Find("Canvas").GetComponent<UIScript>();
        StartWave();
        waveCountdown = 0;
        
    }

    private void FixedUpdate()
    {
        if (waveCountdown % 50 == 0)
        {
            uiScript.setWaveCountdown(8 - (waveCountdown / 50));
        }
        if (waveCountdown == 400)
        {
            waveCountdown = 0;
            StartWave();
        }
        if (!isSpawning)
        {
            waveCountdown++;
            return;
        }
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / enemiesPerSecond) && (enemiesLeftToSpawn > 0)){
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
        if((enemiesLeftToSpawn == 0) && (enemiesAlive == 0))
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    private void SpawnEnemy()
    {
        int index = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, Levelmanager.main.startPoint.position, Quaternion.identity);
    }
    private void StartWave()
    {
        uiScript.setWaveNumber(currentWave);
        isSpawning = true;
        enemiesLeftToSpawn = enemiesPerWave();
    }

    private void EndWave()
    {
        enemiesPerSecond += 0.25f;
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        waveCountdown = -1;
    }

    private int enemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, diffcultyFactor));
    }
}
