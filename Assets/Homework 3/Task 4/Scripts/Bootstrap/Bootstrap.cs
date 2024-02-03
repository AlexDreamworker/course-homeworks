using UnityEngine;

namespace Homework3.Task4
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;

        [Space]
        [SerializeField] private EnemyConfig _enemyConfig;

        private InputReader _inputReader;
        private Score _score;

        private void Awake() 
        {
            _inputReader = new InputReader();
            _score = new Score(_spawner, _enemyConfig.ScoreConfig);

            _spawner.Initialize(_inputReader, _enemyConfig.WeightConfig);
            _spawner.StartWork();
        }

        private void Update() => _inputReader.UpdateUserInput();

        private void OnDisable() => _score.Dispose();
    }
}