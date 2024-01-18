using System;
using UnityEngine;

namespace Homework1.Task2 
{
    public class Pistol : Weapon, IReloadable
    {
        [SerializeField, Range(0, 100)] private int _ammoCount = 10;

        private const int AMMO_SPEND = 1;

        private void Awake() => _camera = Camera.main;

        public override void Fire()
        {
            if (IsAmmoEmpty())
            {
                Debug.Log($"<color=orange>Pistol ammo is empty...</color>");
                return;
            }

            Vector3 targetPoint = Physics.Raycast(Ray, out RaycastHit hit) ? hit.point : Ray.GetPoint(RAY_DISTANCE);
            Vector3 direction = targetPoint - SpawnPointPosition;

            GameObject bulletGO = Instantiate(_bulletPrefab, SpawnPointPosition, Quaternion.identity);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.AddForce(direction.normalized);

            _ammoCount -= AMMO_SPEND;

            Debug.Log($"<color=orange>Pistol shooting!</color> Ammo count is: {_ammoCount}");
        }

        public bool IsAmmoEmpty()
        {
            return _ammoCount < AMMO_SPEND;
        }
    }
}