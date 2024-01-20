using System.Collections.Generic;
using UnityEngine;

namespace Homework1.Task3 
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Trader _trader;
        [SerializeField] private Player _player;

        [Space]
        [SerializeField] private List<Detector> _detectors = new List<Detector>();

        private Dictionary<RaceType, ITradeStrategy> _tradeStrategiesMap = new Dictionary<RaceType, ITradeStrategy>();
        private RaceChanger _raceChanger;

        private void Awake()
        {
            _raceChanger = new RaceChanger(_detectors);

            AddStrategies();

            _trader.SetTradeStrategy(_tradeStrategiesMap[RaceType.Goblin]);
        }

        private void OnEnable() => _player.RaceChanged += OnRaceChanged;

        private void OnDisable() => _player.RaceChanged -= OnRaceChanged;

        private void OnDestroy() => _raceChanger.Dispose();

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