using System;
using UnityEngine;
using Zenject;

namespace Homework4.Task2
{
    public class GameplayMediator : IDisposable
    {
        private DefeatPanel _defeatPanel;
        private Level _level;

        [Inject]
        private void Construct(Level level, DefeatPanel defeatPanel) 
        {
            _level = level;
            _defeatPanel = defeatPanel;

            _level.Defeat += OnLevelDefeat;
        }

        public void Dispose()
        {
            _level.Defeat -= OnLevelDefeat;
        }

        private void OnLevelDefeat() => _defeatPanel.Show();

        public void RestartLevel()
        {
            Debug.Log("Mediator: RestartLevel");

            _defeatPanel.Hide();
            _level.Restart();
        }    
    }
}