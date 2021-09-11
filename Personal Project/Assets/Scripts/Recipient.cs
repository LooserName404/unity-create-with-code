using UnityEngine;

namespace ChefCatch
{
    [RequireComponent(typeof(Rigidbody))]
    public class Recipient : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private FoodType targetFoodType;

        private const float ZDestroy = 6f;

        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        
        private void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z > ZDestroy)
            {
                Destroy(gameObject);
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Food"))
            {
                var food = other.gameObject.GetComponent<Food>();
                if (food.foodType == targetFoodType)
                {
                    Destroy(gameObject);
                    Destroy(other.gameObject);
                }
            }
        }
    }
}