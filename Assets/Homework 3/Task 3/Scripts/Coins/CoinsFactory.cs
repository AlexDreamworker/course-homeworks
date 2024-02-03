using System;
using UnityEngine;

namespace Homework3.Task3
{
    [CreateAssetMenu(fileName = "CoinsFactory", menuName = "HW3-T3/Factory/CoinsFactory")]
    public class CoinsFactory : ScriptableObject
    {
        [SerializeField] private EmptyCoin _emptyCoinPrefab;
        [SerializeField] private StandartCoin _standartCoinPrefab;
        [SerializeField] private RandomCoin _randomCoinPrefab;

        public Coin Get(CoinType type)
        {
            switch (type)
            {
                case CoinType.Empty:
                    return Instantiate(_emptyCoinPrefab);

                case CoinType.Standart:
                    return Instantiate(_standartCoinPrefab);

                case CoinType.Random:
                    return Instantiate(_randomCoinPrefab);

                default:
                    throw new ArgumentException($"Unknown type: {type}");
            }
        }
    }
}