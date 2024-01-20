using System;
using System.Collections.Generic;
using UnityEngine;

namespace Homework1.Task2 
{
    public class Shotgun : Weapon
    {
        [SerializeField] private List<Transform> _bulletSpawnPoints = new List<Transform>();
        [SerializeField, Range(0, 100)] private int _ammoCount = 30;

        private int _ammoSpend;

        public override bool IsCanShoot => _ammoCount >= _ammoSpend;

        private void Start()
        {
            _ammoSpend = _bulletSpawnPoints.Count;
        }

        public override void Fire()
        {
            foreach (Transform point in _bulletSpawnPoints)
                CreateBullet(point.position);

            _ammoCount -= _ammoSpend;

            Debug.Log($"<color=yellow>Shotgun shooting!</color> Ammo count is: {_ammoCount}");
        }
    }
}