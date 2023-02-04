using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class AISpawner : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private List<Transform> spawnPosList = new List<Transform>();
    [SerializeField] private float timeBetweenSpawns = 2f;

    private int currentSpawner;
    private float timer;

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            TryToSpawnEnemy();
            ResetTimer();
        }

    }

    private void TryToSpawnEnemy()
    {
        if (spawnPosList.Count > 0)
        {
            Instantiate(enemyPrefab, spawnPosList[currentSpawner].position, Quaternion.identity);
            currentSpawner++;

            if (currentSpawner >= spawnPosList.Count)
                currentSpawner = 0;
        }
    }

    private void ResetTimer()
    {
        timer = timeBetweenSpawns;
    }

}