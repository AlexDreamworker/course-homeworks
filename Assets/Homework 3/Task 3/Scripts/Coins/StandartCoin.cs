using UnityEngine;

namespace Homework3.Task3
{
    public class StandartCoin : Coin
    {
        [SerializeField, Range(0, 50)] private int _value = 10;

        protected override void AddCoins(ICoinPicker coinPicker) => coinPicker.Add(_value);
    }
}