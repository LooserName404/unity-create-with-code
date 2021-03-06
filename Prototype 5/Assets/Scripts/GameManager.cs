using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public List<GameObject> targets;

        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI gameOverText;
        public Button restartButton;
        public GameObject titleScreen;

        public bool isGameActive;

        private float _spawnRate = 1f;
        private int score;

        private IEnumerator SpawnTarget()
        {
            while (isGameActive)
            {
                yield return new WaitForSeconds(_spawnRate);
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
            }
        }

        public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;
        }

        public void GameOver()
        {
            restartButton.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            isGameActive = false;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void StartGame(int difficulty)
        {
            isGameActive = true;

            _spawnRate /= difficulty;
            
            score = 0;
            titleScreen.gameObject.SetActive(false);
            StartCoroutine(SpawnTarget());
            UpdateScore(0);
        }
    }
}