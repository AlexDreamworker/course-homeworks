using UnityEngine;
using Zenject;

namespace Homework4.Task1
{
    public class Player : MonoBehaviour, IEnemyTarget
    {
        private int _maxHealth;
        private int _health;

        public Vector3 Position => transform.position;

        [Inject]
        private void Construct(PlayerStatsConfig playerStatsConfig)
        {
            _maxHealth = _health = playerStatsConfig.MaxHealth;
            Debug.Log($"I have {_health} HP");
        }

        public void TakeDamage(int damage)
        {
            // Check damage
            // Take damage
        }
    }
}