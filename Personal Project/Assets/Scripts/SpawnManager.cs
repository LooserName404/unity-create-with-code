using UnityEngine;
using Random = UnityEngine.Random;

namespace ChefCatch
{
    public class SpawnManager : MonoBehaviour
    {
        private const float InitialDelay = 2;

        [SerializeField] private GameObject[] foodPrefabs;
        [SerializeField] private Positions positions;

        private void Start()
        {
            Invoke(nameof(Spawn), InitialDelay);
        }

        private void Spawn()
        {
            var randPosIndex = Random.Range(0, positions.Array.Length);
            var randPrefabIndex = Random.Range(0, foodPrefabs.Length);
            
            Instantiate(foodPrefabs[randPrefabIndex], positions.Array[randPosIndex] + new Vector3(0, 0, 10), Quaternion.identity);
            
            var randTime = Random.Range(1.5f, 3f);
            Invoke(nameof(Spawn), randTime);
        }
    }
}