using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Target : MonoBehaviour
    {
        public int pointValue;

        public ParticleSystem explosionParticle;
        
        private Rigidbody _targetRb;
        private GameManager _gameManager;
        
        private float _minSpeed = 13f;
        private float _maxSpeed = 16f;
        private float _maxTorque = 10f;
        private float _xRange = 4f;
        private float _ySpawnPos = -6f;

        private void Start()
        {
            _targetRb = GetComponent<Rigidbody>();
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
            _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

            transform.position = RandomSpawnPos();
        }

        private void OnMouseDown()
        {
            if (_gameManager.isGameActive)
            {
                _gameManager.UpdateScore(pointValue);
                Destroy(gameObject);
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad"))
            {
                _gameManager.GameOver();
            }
        }

        private Vector3 RandomSpawnPos()
        {
            return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);
        }

        private float RandomTorque()
        {
            return Random.Range(-_maxTorque, _maxTorque);
        }

        private Vector3 RandomForce()
        {
            return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
        }
    }
}