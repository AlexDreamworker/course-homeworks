using System;

namespace Homework2.Task4
{
    public class HUDMediator : IDisposable
    {
        private HUDPanel _hud;
        private Player _player;

        public HUDMediator(HUDPanel hud, Player player)
        {
            _hud = hud;
            _player = player;

            _player.Defeat += OnPlayerDefeat;
            _player.HealthChanged += OnHealthChanged;
            _player.LevelChanged += OnLevelChanged;
        }

        public void Dispose()
        {
            _player.Defeat -= OnPlayerDefeat;
            _player.HealthChanged -= OnHealthChanged;
            _player.LevelChanged -= OnLevelChanged;
        }

        public void Restart()
        {
            _hud.HideRestartButton();
            _player.Restart();
        }

        private void OnPlayerDefeat() => _hud.ShowRestartButton();

        private void OnHealthChanged(int health, int maxHealth) => _hud.UpdateHealth(health, maxHealth);

        private void OnLevelChanged(int level, int levelScore, int levelScoreLimit) 
            => _hud.UpdateLevel(level, levelScore, levelScoreLimit);
    }
}