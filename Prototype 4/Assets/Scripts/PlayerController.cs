using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5.0f;
        public bool hasPowerup;
        public GameObject powerupIndicator;

        private Rigidbody _playerRb;
        private GameObject _focalPoint;
        private float _powerupStrength = 15f;

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
            _focalPoint = GameObject.Find("FocalPoint");
        }

        private void Update()
        {
            float forwardInput = Input.GetAxis("Vertical");
            _playerRb.AddForce(_focalPoint.transform.forward * speed * forwardInput);
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Powerup"))
            {
                hasPowerup = true;
                powerupIndicator.SetActive(true);
                Destroy(other.gameObject);
                StartCoroutine(PowerupCountdownRoutine());
            }
        }

        private IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7f);
            hasPowerup = false;
            powerupIndicator.SetActive(false);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy") && hasPowerup)
            {
                Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);
                
                Debug.Log("Collided with " + other.gameObject.name + " with powerup set to " + hasPowerup);
                enemyRb.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);
            }
        }
    }
}