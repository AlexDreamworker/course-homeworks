using System;
using Zenject;

namespace Homework4.Task1
{
    public class EnemyFactory
    {
        private EnemyConfig _small, _medium, _large;

        private DiContainer _container;

        private IEnemyAssetProvider _assetProvider;

        public EnemyFactory(DiContainer container, IEnemyAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;

            Load();
        }

        public Enemy Get(EnemyType enemyType)
        {
            EnemyConfig config = GetConfig(enemyType);
            Enemy instance = _container.InstantiatePrefabForComponent<Enemy>(config.Prefab);
            instance.Initialize(config.Health, config.Speed);

            return instance;
        }

        private EnemyConfig GetConfig(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.Small:
                    return _small;

                case EnemyType.Medium:
                    return _medium;

                case EnemyType.Large:
                    return _large;

                default:
                    throw new ArgumentException(nameof(enemyType));
            }
        }

        private void Load()
        {
            _small = _assetProvider.GetConfig(EnemyType.Small);
            _medium = _assetProvider.GetConfig(EnemyType.Medium);
            _large = _assetProvider.GetConfig(EnemyType.Large);
        }
    }
}