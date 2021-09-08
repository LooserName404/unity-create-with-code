using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MoveLeft : MonoBehaviour
    {
        private float _speed = 30f;
        private PlayerController _playerControllerScript;
        private float _leftBound = -15f;

        private void Start()
        {
            _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (_playerControllerScript.gameOver == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
            }

            if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}