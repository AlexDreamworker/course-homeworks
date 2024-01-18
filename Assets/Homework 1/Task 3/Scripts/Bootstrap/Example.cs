using System.Collections.Generic;
using UnityEngine;

namespace Homework1.Task3 
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private Trader _trader;
        [SerializeField] private Player _player;

        private Dictionary<RaceType, ITradeStrategy> _tradeStrategiesMap = new Dictionary<RaceType, ITradeStrategy>();

        private void Awake()
        {
            AddStrategies();

            _trader.SetTradeStrategy(_tradeStrategiesMap[RaceType.Goblin]);
        }

        private void OnEnable() => _player.RaceChanged += OnRaceChanged;

        private void OnDisable() => _player.RaceChanged -= OnRaceChanged;

        private void AddStrategies() 
        {
            _tradeStrategiesMap.Add(RaceType.Goblin, new NoTradeStrategy());
            _tradeStrategiesMap.Add(RaceType.Human, new TradeArmorStrategy());
            _tradeStrategiesMap.Add(RaceType.Elf, new TradeFruitsStrategy());
        }

        private void OnRaceChanged(RaceType type) 
        {
            _trader.SetTradeStrategy(_tradeStrategiesMap[type]);
        }
    }
}