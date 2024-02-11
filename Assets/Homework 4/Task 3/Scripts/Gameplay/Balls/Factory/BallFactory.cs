using Zenject;

namespace Homework4.Task3
{
    public class BallFactory
    {
        private DiContainer _container;
        private BallConfig _config;

        [Inject]
        private void Construct(DiContainer container, BallConfig config) 
        {
            _container = container;
            _config = config;
        }

        public Ball Get()
        {   
            Ball instance = _container.InstantiatePrefabForComponent<Ball>(_config.RandomPrefab);
            return instance;
        }
    }
}