using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework3.Task3
{
    public class CoinsSpawner : MonoBehaviour
    {
        [SerializeField, Range(0, 50)] private float _spawnCooldown = 1f;
        [SerializeField] private CoinsFactory _coinsFactory;

        [Space]
        [SerializeField] private List<Transform> _spawnPoints;

        private List<Vector3> _freeSpawnPoints = new List<Vector3>();

        private Coroutine _spawn;

        private void Awake()
        {
            foreach (Transform transform in _spawnPoints)
                _freeSpawnPoints.Add(transform.position);
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

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_freeSpawnPoints.Count <= 0)
                {
                    yield return null;
                }
                else
                {
                    CoinType coinType = (CoinType)Random.Range(0, Enum.GetValues(typeof(CoinType)).Length);
                    Coin coin = _coinsFactory.Get(coinType);

                    coin.Collected += OnCollected;
                    
                    Vector3 randomPosition = _freeSpawnPoints[Random.Range(0, _freeSpawnPoints.Count)];
                    coin.SetPosition(randomPosition);
                    _freeSpawnPoints.Remove(randomPosition);
                    
                    yield return new WaitForSeconds(_spawnCooldown);
                }
            }
        }

        private void OnCollected(Coin coin)
        {
            coin.Collected -= OnCollected;
            
            _freeSpawnPoints.Add(coin.transform.position);
        }
    }
}