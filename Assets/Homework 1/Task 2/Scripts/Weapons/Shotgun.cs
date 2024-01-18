using System;
using UnityEngine;

namespace Homework1.Task2 
{
    public class Shotgun : Weapon, IReloadable
    {
        [SerializeField, Range(0, 100)] private int _ammoCount = 30;

        private const int AMMO_SPEND = 3;
        private const float OFFSET_X = 0.2f;

        private void Awake() => _camera = Camera.main;

        public override void Fire()
        {
            if (IsAmmoEmpty())
            {
                Debug.Log($"<color=yellow>Shotgun ammo is empty...</color>");
                return;
            }

            Vector3 targetPoint = Physics.Raycast(Ray, out RaycastHit hit) ? hit.point : Ray.GetPoint(RAY_DISTANCE);
            Vector3 direction = targetPoint - SpawnPointPosition;

            for (var i = 0; i < AMMO_SPEND; i++)
            {
                GameObject bulletGO = Instantiate(_bulletPrefab, CalculateOffset(i), Quaternion.identity);
                Bullet bullet = bulletGO.GetComponent<Bullet>();
                bullet.AddForce(direction.normalized);
            }

            _ammoCount -= AMMO_SPEND;

            Debug.Log($"<color=yellow>Shotgun shooting!</color> Ammo count is: {_ammoCount}");
        }

        public bool IsAmmoEmpty()
        {
            return _ammoCount < AMMO_SPEND;
        }

        private Vector3 CalculateOffset(int iterationIndex) 
        {
            Vector3 offset = Vector3.zero;

            switch (iterationIndex)
            {
                case 0:
                    offset = SpawnPointPosition;
                    break;
                case 1:
                    offset = new Vector3(SpawnPointPosition.x - OFFSET_X, SpawnPointPosition.y, SpawnPointPosition.z);
                    break;
                case 2:
                    offset = new Vector3(SpawnPointPosition.x + OFFSET_X, SpawnPointPosition.y, SpawnPointPosition.z);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(iterationIndex));     
            }

            return offset;
        }
    }
}