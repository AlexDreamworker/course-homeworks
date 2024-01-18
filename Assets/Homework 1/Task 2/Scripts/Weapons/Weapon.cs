using UnityEngine;

namespace Homework1.Task2 
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected GameObject _bulletPrefab;
        [SerializeField] protected Transform _bulletSpawnPoint;

        protected const float RAY_DISTANCE = 50f;

        protected Camera _camera;

        protected Vector3 SpawnPointPosition => _bulletSpawnPoint.position;
        protected Ray Ray => _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        public void Activate() => gameObject.SetActive(true);

        public void Deactivate() => gameObject.SetActive(false);

        public abstract void Fire();
    }
}