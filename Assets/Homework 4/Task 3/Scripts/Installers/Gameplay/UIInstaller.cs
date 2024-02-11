using UnityEngine;
using Zenject;

namespace Homework4.Task3
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private GameplayHUD _gameplayHUD;
        
        public override void InstallBindings()
        { 
            Container.Bind<GameplayHUD>().FromInstance(_gameplayHUD).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayHUDMediator>().AsSingle();
        }
    }
}