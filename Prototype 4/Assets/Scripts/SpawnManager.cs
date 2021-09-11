﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public GameObject powerupPrefab;
        
        public int enemyCount;
        public int waveNumber = 1;

        private float spawnRange = 9f;

        private void Start()
        {
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }

        private void Update()
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;

            if (enemyCount == 0)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                SpawnPowerup();
            }
        }

        private void SpawnPowerup()
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }

        private void SpawnEnemyWave(int enemiesToSpawn)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }

        private Vector3 GenerateSpawnPosition()
        {
            float spawnPosX = Random.Range(-spawnRange, spawnRange);
            float spawnPosZ = Random.Range(-spawnRange, spawnRange);

            Vector3 randomPos = new Vector3(spawnPosX, 0.1f, spawnPosZ);
            return randomPos;
        }
    }
}