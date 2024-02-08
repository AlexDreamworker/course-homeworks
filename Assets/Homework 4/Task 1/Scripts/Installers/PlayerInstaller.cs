using UnityEngine;
using Zenject;


namespace Homework4.Task1
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Transform _playerSpawnPoint;

        [SerializeField] private PlayerStatsConfig _playerStatsConfig;

        public override void InstallBindings() 
        {
            BindConfigs();
            BindInstance();
        }

        private void BindConfigs() 
        {
            Container.Bind<PlayerStatsConfig>().FromInstance(_playerStatsConfig).AsSingle();
        }

        private void BindInstance()
        {
            Player player = Container.InstantiatePrefabForComponent<Player>(
                _playerPrefab, 
                _playerSpawnPoint.position, 
                Quaternion.identity, 
                null
            );

            Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();    
        }
    }
}