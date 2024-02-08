using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Homework4.Task1
{
    public class EnemySpawner : ITickable
    {
        private EnemySpawnerConfig _config;
        private EnemySpawnPoints _points;

        private EnemyFactory _enemyFactory;

        private float _timeRemaining;

        [Inject]
        private void Construct(EnemyFactory enemyFactory, EnemySpawnerConfig config, EnemySpawnPoints points)
        {
            _enemyFactory = enemyFactory;
            _config = config;
            _points = points;
        }

        public void Tick()
        {
            _timeRemaining += Time.deltaTime;

            if (_timeRemaining < _config.SpawnCooldown) 
                return;

            Enemy enemy = _enemyFactory.Get((EnemyType)Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_points.GetRandom());

            _timeRemaining = 0;
        }
    }
}