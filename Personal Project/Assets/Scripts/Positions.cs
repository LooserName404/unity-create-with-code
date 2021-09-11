using UnityEngine;

namespace ChefCatch
{
    [CreateAssetMenu(fileName = "Positions", menuName = "Positions", order = 0)]
    public class Positions : ScriptableObject
    {
        public Vector3 Left;
        public Vector3 Middle;
        public Vector3 Right;

        public Vector3[] Array;

        private void OnEnable()
        {
            Array = new[] { Left, Middle, Right };
        }
    }
}