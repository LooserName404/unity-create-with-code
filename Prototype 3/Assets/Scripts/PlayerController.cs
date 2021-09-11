using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
        public float jumpForce = 10f;
        public float gravityModifier;
        public bool isOnGround = true;
        public bool gameOver = false;
        
        public ParticleSystem explosionParticle;
        public ParticleSystem dirtParticle;

        public AudioClip jumpSound;
        public AudioClip crashSound;
        
        private Rigidbody _playerRb;
        private Animator _playerAnim;
        private AudioSource _playerAudio;

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
            _playerAnim = GetComponent<Animator>();
            _playerAudio = GetComponent<AudioSource>();
            Physics.gravity *= gravityModifier;
        }

        private void Update()
        {
            if (isOnGround && !gameOver && Input.GetKeyDown(KeyCode.Space))
            {
                _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                _playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                _playerAudio.PlayOneShot(jumpSound);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
                dirtParticle.Play();
            }
            else if (other.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("GameOver");
                gameOver = true;
                dirtParticle.Stop();
                explosionParticle.Play();
                _playerAudio.PlayOneShot(crashSound);
                _playerAnim.SetBool("Death_b", true);
                _playerAnim.SetInteger("DeathType_int", 1);
            }
        }
    }
}