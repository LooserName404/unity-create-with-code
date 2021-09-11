using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Enemy : MonoBehaviour
    {
        public float speed;

        private Rigidbody _enemyRb;
        private GameObject _player;

        private void Start()
        {
            _enemyRb = GetComponent<Rigidbody>();
            _player = GameObject.Find("Player");
        }

        private void Update()
        {
            Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
            _enemyRb.AddForce(lookDirection * speed);

            if (transform.position.y < -10)
            {
                Destroy(gameObject);
            }
        }
    }
}