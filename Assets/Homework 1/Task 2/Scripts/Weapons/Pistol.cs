using System;
using UnityEngine;

namespace Homework1.Task2 
{
    public class Pistol : Weapon
    {
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField, Range(0, 100)] private int _ammoCount = 10;

        private int _ammoSpend = 1;

        public override bool IsCanShoot => _ammoCount >= _ammoSpend;

        public override void Fire()
        {
            CreateBullet(_bulletSpawnPoint.position);

            _ammoCount -= _ammoSpend;

            Debug.Log($"<color=orange>Pistol shooting!</color> Ammo count is: {_ammoCount}");
        }
    }
}