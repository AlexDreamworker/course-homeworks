using UnityEngine;
using Zenject;

namespace Homework4.Task3
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private Clicker _clicker;

        public override void InstallBindings()
        { 
            Container.BindInterfacesAndSelfTo<InputReader>().AsSingle();
            Container.Bind<Clicker>().FromInstance(_clicker).AsSingle();
        }
    }
}