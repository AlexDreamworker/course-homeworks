using UnityEngine;

namespace Homework3.Task4
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "HW3-T4/Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private ScoreConfig _scoreConfig;
        [SerializeField] private WeightConfig _weightConfig;

        public ScoreConfig ScoreConfig => _scoreConfig;
        public WeightConfig WeightConfig => _weightConfig;
    }
}