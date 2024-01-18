using UnityEngine;

namespace Homework1.Task2 
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField, Range(0, 50f)] private float _force = 10f;

        private Rigidbody _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        private void OnTriggerEnter(Collider other) => Destroy(gameObject);

        public void AddForce(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}