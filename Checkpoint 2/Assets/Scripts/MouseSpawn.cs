using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MouseSpawn : MonoBehaviour
    {
        [SerializeField] private float zPosition;
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private float forceToAdd;
        [SerializeField] private Text shotsText;

        private IEnumerator _addForceEnumerator;
        private Rigidbody _currentBallRb;
        private float _force;
        private int _shots = 0;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Input.mousePosition;
                var position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, zPosition));
                var ball = Instantiate(ballPrefab, position, Quaternion.identity);
                _currentBallRb = ball.GetComponent<Rigidbody>();
                _currentBallRb.useGravity = false;
                _addForceEnumerator = AddForce();
                StartCoroutine(_addForceEnumerator);
            }
        }

        private IEnumerator AddForce()
        {
            while (true)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    _currentBallRb.useGravity = true;
                    _currentBallRb.AddForce(Vector3.forward * _force, ForceMode.Impulse);
                    _force = 0f;
                    _shots++;
                    shotsText.text = "Shots: " + _shots;
                    yield break;
                }
                
                _force += forceToAdd;
                yield return null;
            }
        }
    }
}