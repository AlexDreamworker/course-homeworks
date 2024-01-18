using UnityEngine;

namespace Homework1.Task2 
{
    public class Blaster : Weapon
    {
        private void Awake() => _camera = Camera.main;

        public override void Fire()
        {
            Vector3 targetPoint = Physics.Raycast(Ray, out RaycastHit hit) ? hit.point : Ray.GetPoint(RAY_DISTANCE);
            Vector3 direction = targetPoint - SpawnPointPosition;

            GameObject bulletGO = Instantiate(_bulletPrefab, SpawnPointPosition, Quaternion.identity);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.AddForce(direction.normalized);
            
            Debug.Log($"<color=red>Blaster shooting!</color>");
        }
    }
}