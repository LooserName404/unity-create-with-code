using DefaultNamespace;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    
    private Vector3 _spawnPos = new Vector3(25f, 0f, 0f);
    private float _startDelay = 2;
    private float _repeatRate = 3;
    private PlayerController _playerControllerScript;

    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), _startDelay, _repeatRate);
    }

    private void SpawnObstacle()
    {
        if (!_playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
