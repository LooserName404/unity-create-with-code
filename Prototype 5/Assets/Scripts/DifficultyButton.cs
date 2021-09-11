using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class DifficultyButton : MonoBehaviour
    {
        public int difficulty;
        
        private Button _button;
        private GameManager _gameManager;

        private void Start()
        {
            _button = GetComponent<Button>();
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            
            _button.onClick.AddListener(SetDifficulty);;
        }

        private void SetDifficulty()
        {
            _gameManager.StartGame(difficulty);
        }
    }
}