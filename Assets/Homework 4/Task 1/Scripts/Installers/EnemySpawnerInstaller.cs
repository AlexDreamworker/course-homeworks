using UnityEngine;
using Zenject;

namespace Homework4.Task1
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private EnemySpawnerConfig _enemySpawnerConfig;
        
        [SerializeField] private EnemySpawnPoints _enemySpawnPoints;

        public override void InstallBindings()
        {
            BindAssetProvider();
            BindFactory();
            BindConfigs();
            BindSpawnPoints();
            BindSpawner();
        }

        private void BindAssetProvider() 
        {
            Container.BindInterfacesAndSelfTo<EnemyResourcesAssetProvider>().AsSingle();
        }

        private void BindFactory() 
        {
            Container.Bind<EnemyFactory>().AsSingle();
        }

        private void BindConfigs() 
        {
            Container.Bind<EnemySpawnPoints>().FromInstance(_enemySpawnPoints).AsSingle();
        }

        private void BindSpawnPoints() 
        {
            Container.Bind<EnemySpawnerConfig>().FromInstance(_enemySpawnerConfig).AsSingle();
        }

        private void BindSpawner() 
        {
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();
        }
    }
}