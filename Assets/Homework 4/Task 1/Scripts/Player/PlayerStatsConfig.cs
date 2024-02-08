using UnityEngine;

namespace Homework4.Task1
{
    [CreateAssetMenu(fileName = "PlayerStatsConfig", menuName = "HW4-T1/Configs/PlayerStatsConfig")]
    public class PlayerStatsConfig : ScriptableObject
    {
        [SerializeField, Range(0, 150)] private int _maxHealth;

        public int MaxHealth => _maxHealth;
    }
}