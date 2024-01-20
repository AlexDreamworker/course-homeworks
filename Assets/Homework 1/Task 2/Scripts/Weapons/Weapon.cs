using UnityEngine;

namespace Homework1.Task2 
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;

        private const float RAY_DISTANCE = 50f;

        private Camera _camera;

        public virtual bool IsCanShoot { get; private set; } = true;
        private Ray Ray => _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        private void Awake() => _camera = Camera.main;

        public void Activate() => gameObject.SetActive(true);

        public void Deactivate() => gameObject.SetActive(false);

        public abstract void Fire();

        protected void CreateBullet(Vector3 position) 
        {
            Vector3 targetPoint = Physics.Raycast(Ray, out RaycastHit hit) ? hit.point : Ray.GetPoint(RAY_DISTANCE);
            Vector3 direction = targetPoint - position;

            Bullet bullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
            bullet.Launch(direction.normalized);
        }
    }
}