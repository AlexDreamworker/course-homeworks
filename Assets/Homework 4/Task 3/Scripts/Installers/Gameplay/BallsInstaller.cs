using UnityEngine;
using Zenject;

namespace Homework4.Task3
{
    public class BallsInstaller : MonoInstaller
    {
        [SerializeField] private BallConfig _ballConfig;
        [SerializeField] private BallSpawnPoints _ballSpawnPoints;
        
        public override void InstallBindings()
        { 
            Container.Bind<BallsList>().AsSingle().NonLazy();
            Container.Bind<BallFactory>().AsSingle();
            Container.Bind<BallConfig>().FromInstance(_ballConfig).AsSingle();
            Container.Bind<BallSpawnPoints>().FromInstance(_ballSpawnPoints).AsSingle();
            Container.BindInterfacesAndSelfTo<BallSpawner>().AsSingle();
        }
    }
}