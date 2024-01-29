using System;

namespace Homework2.Task4
{
    public class Player : IDisposable
    {
        public event Action Defeat;
        public event Action<int, int> HealthChanged;
        public event Action<int, int, int> LevelChanged;

        private InputReader _inputReader;
        private PlayerConfig _config;

        private int _health;
        private int _maxHealth;
        private int _level;
        private int _levelScore;
        private int _levelScoreLimit;

        private bool _isDefeat;

        public Player(InputReader inputReader, PlayerConfig config)
        {
            _inputReader = inputReader;
            _config = config;

            _inputReader.LevelUpButtonChanged += OnLevelUpButtonChanged;
            _inputReader.DamageButtonChanged += OnDamageButtonChanged;
        }

        public void Dispose()
        {
            _inputReader.LevelUpButtonChanged -= OnLevelUpButtonChanged;
            _inputReader.DamageButtonChanged -= OnDamageButtonChanged;
        }

        public void Start() 
        {
            _health = _config.Health;
            _maxHealth = _config.MaxHealth;
            _level = _config.Level;
            _levelScore = _config.LevelScore;
            _levelScoreLimit = _config.LevelScoreLimit;

            _isDefeat = false;

            HealthChanged?.Invoke(_health, _maxHealth);
            LevelChanged?.Invoke(_level, _levelScore, _levelScoreLimit);
        }

        public void Restart() => Start();

        private void OnLevelUpButtonChanged() 
        {
            if (_isDefeat)
                return;
            
            _levelScore ++;

            if (_levelScore > _levelScoreLimit) 
            {
                _level ++;
                _levelScoreLimit += _config.LevelScoreLimit;
                _maxHealth += _config.HealthImprovement;
                _health = _maxHealth;

                HealthChanged?.Invoke(_health, _maxHealth);
            }

            LevelChanged?.Invoke(_level, _levelScore, _levelScoreLimit);
        }

        private void OnDamageButtonChanged() 
        {    
            if (_isDefeat)
                return;

            _health -= _config.Damage;
            
            if (_health <= 0) 
            {
                _health = 0;
                _isDefeat = true;

                Defeat?.Invoke();
            }

            HealthChanged?.Invoke(_health, _maxHealth);
        }
    }
}