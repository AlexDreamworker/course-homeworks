using UnityEngine;

namespace Homework1.Task2 
{
    public class Blaster : Weapon
    {
        [SerializeField] private Transform _bulletSpawnPoint;

        public override void Fire()
        {
            CreateBullet(_bulletSpawnPoint.position);
            
            Debug.Log($"<color=red>Blaster shooting!</color>");
        }
    }
}