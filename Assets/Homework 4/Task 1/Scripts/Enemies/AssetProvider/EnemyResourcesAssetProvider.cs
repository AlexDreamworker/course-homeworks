using System;
using System.IO;
using UnityEngine;

namespace Homework4.Task1
{
    public class EnemyResourcesAssetProvider : IEnemyAssetProvider
    {
        private const string ENEMY_SMALL = "EnemySmallConfig";
        private const string ENEMY_MEDIUM = "EnemyMediumConfig";
        private const string ENEMY_LARGE = "EnemyLargeConfig";

        private const string CONFIGS_PATH = "Homework 4/Task 1/Enemies";

        public EnemyConfig GetConfig(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.Small:
                    return Resources.Load<EnemyConfig>(Path.Combine(CONFIGS_PATH, ENEMY_SMALL));;

                case EnemyType.Medium:
                    return Resources.Load<EnemyConfig>(Path.Combine(CONFIGS_PATH, ENEMY_MEDIUM));

                case EnemyType.Large:
                    return Resources.Load<EnemyConfig>(Path.Combine(CONFIGS_PATH, ENEMY_LARGE));

                default:
                    throw new ArgumentException($"Unknown EnemyType: {enemyType}");
            }
        }
    }
}