using UnityEngine;

namespace Homework2.Task4
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "HW2-T4/Player/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField, Range(0, 100)] private int _health = 100;
        [SerializeField, Range(0, 100)] private int _maxHealth = 100;

        [Space]
        [SerializeField, Range(1, 80)] private int _level = 1;
        [SerializeField, Range(0, 10)] private int _levelScore = 0;
        [SerializeField, Range(10, 100)] private int _levelScoreLimit = 10;

        [Space]
        [SerializeField, Range(1, 100)] private int _healthImprovement = 10;
        [SerializeField, Range(1, 100)] private int _damage = 10;

        public int Health => _health;
        public int MaxHealth => _maxHealth;
        public int Level => _level;
        public int LevelScore => _levelScore;
        public int LevelScoreLimit => _levelScoreLimit;
        public int HealthImprovement => _healthImprovement;
        public int Damage => _damage;
    }
}