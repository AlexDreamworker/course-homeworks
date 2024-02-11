using System;
using Zenject;

namespace Homework4.Task3
{
    public class GameplayHUDMediator : IDisposable
    {
        private Level _level;
        private GameplayHUD _gameplayHUD;

        [Inject]
        private void Construct(Level level, GameplayHUD gameplayHUD) 
        {
            _level = level;
            _gameplayHUD = gameplayHUD;

            _level.Failed += OnLevelFailed;
            _level.Completed += OnLevelCompleted;
        }

        public void Dispose()
        {
            _level.Failed -= OnLevelFailed;
            _level.Completed -= OnLevelCompleted;
        }

        private void OnLevelCompleted()
            => _gameplayHUD.ShowWin();

        private void OnLevelFailed()
            => _gameplayHUD.ShowLose();

        public void RestartLevel()
            => _level.Restart();
    }
}