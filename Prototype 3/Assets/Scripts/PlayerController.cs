using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
        public float jumpForce = 10f;
        public float gravityModifier;
        public bool isOnGround = true;
        public bool gameOver = false;
        
        private Rigidbody _playerRb;

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
        }

        private void Update()
        {
            if (isOnGround && Input.GetKeyDown(KeyCode.Space))
            {
                _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }
            else if (other.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("GameOver");
                gameOver = true;
            }
        }
    }
}