using Zenject;

namespace Homework4.Task3
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        { 
            Container.Bind<GameModeFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
        }
    }
}