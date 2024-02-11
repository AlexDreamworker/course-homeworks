using System;
using Zenject;

namespace Homework4.Task3
{
    public class Level : ILevelPause, IInitializable, IDisposable
    {
        public event Action Completed;
        public event Action Failed;
        public event Action<bool> PauseStateChanged;

        private GameModeFactory _gameModeFactory;
        private LevelLoadingData _levelLoadingData;
        private BallSpawner _ballSpawner;

        private GameMode _gameMode;

        [Inject]
        private void Construct(GameModeFactory gameModeFactory, LevelLoadingData levelLoadingData, BallSpawner ballSpawner) 
        {
            _gameModeFactory = gameModeFactory;
            _levelLoadingData = levelLoadingData;
            _ballSpawner = ballSpawner;
        }

        public void Initialize() => Start();

        public void Dispose()
        {
            _gameMode.Completed -= OnCompleted;
            _gameMode.Failed -= OnFailed;
        }

        public void Restart()
        {
            _gameMode.Completed -= OnCompleted;
            _gameMode.Failed -= OnFailed;

            _ballSpawner.Stop();

            Start();
        }

        private void Start() 
        {
            _ballSpawner.Start();

            _gameMode = _gameModeFactory.Get(_levelLoadingData.GameModeType);

            _gameMode.Completed += OnCompleted;
            _gameMode.Failed += OnFailed;

            PauseStateChanged?.Invoke(false);
        }

        private void OnCompleted()
        {
            Completed?.Invoke();
            PauseStateChanged?.Invoke(true);
        }
        private void OnFailed()
        {
            Failed?.Invoke();
            PauseStateChanged?.Invoke(true);
        }
    }
}