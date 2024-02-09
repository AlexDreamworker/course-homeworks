using UnityEngine;
using Zenject;

namespace Homework4.Task2
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private DefeatPanel _defeatPanel;

        public override void InstallBindings()
        {
            BindInput();
            BindLevel(); 
            BindMediator();
            BindUI(); 
        }

        private void BindInput() 
        {
            Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        }

        private void BindLevel() 
        {
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
        }

        private void BindMediator() 
        {
            Container.BindInterfacesAndSelfTo<GameplayMediator>().AsSingle();
        }

        private void BindUI() 
        {
            Container.Bind<DefeatPanel>().FromInstance(_defeatPanel).AsSingle();
        }
    }
}