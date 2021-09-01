using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] animalPrefabs;

        private float spawnRangeX = 20.0f;
        private float spawnPosZ = 20.0f;

        private float startDelay = 2f;
        private float spawnInterval = 1.5f;

        private void Start()
        {
            InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        }

        private void SpawnRandomAnimal()
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
    }
}