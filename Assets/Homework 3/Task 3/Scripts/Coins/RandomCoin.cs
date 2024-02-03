using UnityEngine;

namespace Homework3.Task3
{
    public class RandomCoin : Coin
    {
        [SerializeField, Range(0, 49)] private int _minValue = 1;
        [SerializeField, Range(0, 50)] private int _maxValue = 50;

        private void OnValidate()
        {
            if(_minValue >= _maxValue)
                _maxValue = _minValue + 1;
        }

        protected override void AddCoins(ICoinPicker coinPicker) => coinPicker.Add(Random.Range(_minValue, _maxValue));
    }
}