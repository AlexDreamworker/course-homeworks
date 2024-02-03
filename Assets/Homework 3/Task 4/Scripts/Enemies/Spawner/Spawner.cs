using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework3.Task4
{
    public class Spawner: MonoBehaviour, IEnemyLifetimeNotifier
    {
        public event Action<Enemy> DeathNotified;
        public event Action<Enemy> CreateNotified;

        [SerializeField] private float _spawnCooldown;
        [SerializeField] private EnemyFactory _enemyFactory;

        [Space]
        [SerializeField] private List<Transform> _spawnPoints;

        private Coroutine _spawn;

        private InputReader _inputReader;
        private Weight _weight;
        private SpawnedEnemiesList _spawnedEnemiesList;

        public void Initialize(InputReader inputReader, WeightConfig weightConfig)
        {
            _inputReader = inputReader;

            _weight = new Weight(this, weightConfig);
            _spawnedEnemiesList = new SpawnedEnemiesList();

            _inputReader.KillButtonChanged += KillRandomEnemy;
        }

        private void OnDisable()
        {
            _inputReader.KillButtonChanged -= KillRandomEnemy;

            _weight.Dispose();
        }

        public void StartWork()
        {
            StopWork();

            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        public void KillRandomEnemy()
        {
            Enemy enemy = _spawnedEnemiesList.GetRandom();
            enemy?.Kill();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_weight.IsLimit()) 
                {
                    yield return null;
                }
                else 
                {
                    Enemy enemy = _enemyFactory.Get((EnemyType)Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                    enemy.MoveTo(_spawnPoints[Random.Range(0, _spawnPoints.Count)].position);
                    enemy.Died += OnEnemyDied;
                    _spawnedEnemiesList.Add(enemy);

                    CreateNotified?.Invoke(enemy);

                    yield return new WaitForSeconds(_spawnCooldown);
                }
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            enemy.Died -= OnEnemyDied;

            DeathNotified?.Invoke(enemy);
            _spawnedEnemiesList.Remove(enemy);
        }
    }
}