using UnityEngine;

namespace ChefCatch
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Positions _positions;
        
        private int _positionIndex;

        private void Start()
        {
            _positionIndex = Mathf.FloorToInt(_positions.Array.Length / 2f);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) && _positionIndex - 1 >= 0)
            {
                transform.position = _positions.Array[--_positionIndex];
            }
            else if (Input.GetKeyDown(KeyCode.D) && _positionIndex + 1 < _positions.Array.Length)
            {
                transform.position = _positions.Array[++_positionIndex];
            }
        }
    }
}