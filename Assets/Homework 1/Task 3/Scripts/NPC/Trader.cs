using UnityEngine;

namespace Homework1.Task3 
{
    public class Trader : MonoBehaviour
    {
        private ITradeStrategy _tradeStrategy;

        private void OnTriggerEnter(Collider other) => _tradeStrategy.StartTrading();

        private void OnTriggerExit(Collider other) => _tradeStrategy.StopTrading();

        public void SetTradeStrategy(ITradeStrategy trade) => _tradeStrategy = trade;
    }
}