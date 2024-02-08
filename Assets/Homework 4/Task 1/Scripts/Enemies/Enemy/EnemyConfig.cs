using System;
using UnityEngine;

namespace Homework4.Task1
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "HW4-T1/Configs/EnemyConfig")]
    public class EnemyConfig: ScriptableObject
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField, Range(1, 10)] private int _health;
        [SerializeField, Range(1, 10)] private float _speed;

        public Enemy Prefab => _prefab;
        public int Health => _health;
        public float Speed => _speed;
    }
}