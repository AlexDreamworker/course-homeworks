using UnityEngine;

namespace Homework1.Task2 
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        [Space]
        [SerializeField, Range(0, 50f)] private float _force = 10f;

        private void OnValidate() 
        {
            _rigidbody ??= GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other) => Destroy(gameObject);

        public void Launch(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}