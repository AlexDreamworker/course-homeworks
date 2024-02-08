using UnityEngine;

namespace Homework4.Task1
{
    [CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "HW4-T1/Configs/EnemySpawnerConfig")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [SerializeField] private float _spawnCooldown = 2f;

        public float SpawnCooldown => _spawnCooldown;
    }
}