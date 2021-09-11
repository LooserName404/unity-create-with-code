using UnityEngine;

namespace ChefCatch
{
    public class Food : MonoBehaviour
    {
        public FoodType foodType;
        
        [SerializeField] private float speed;

        private const float ZDestroy = -6f;

        private void Update()
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);

            if (transform.position.z < ZDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}