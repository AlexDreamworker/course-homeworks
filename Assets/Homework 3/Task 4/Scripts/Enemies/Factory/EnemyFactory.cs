using System;
using UnityEngine;

namespace Homework3.Task4
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "HW3-T4/Factory/EnemyFactory")]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] private Human _humanPrefab;
        [SerializeField] private Ork _orkPrefab;
        [SerializeField] private Elf _elfPrefab;

        public Enemy Get(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Elf:
                    return Instantiate(_elfPrefab);

                case EnemyType.Human:
                    return Instantiate(_humanPrefab);

                case EnemyType.Ork:
                    return Instantiate(_orkPrefab);

                case EnemyType.Robot:
                    return Instantiate(_elfPrefab);

                default:
                    throw new ArgumentException(nameof(type));
            }
        }
    }
}