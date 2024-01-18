using UnityEngine;

namespace Homework1.Task3 
{
    public class TradeArmorStrategy : ITradeStrategy
    {
        public void StartTrading()
        {
            Debug.Log("<color=yellow>Trader:</color> Brave <color=orange>HUMAN</color>, you definitely need <color=orange>ARMOR</color> for this trip!");
        }

        public void StopTrading()
        {
            Debug.Log("<color=yellow>Trader:</color> See ya!");
        }
    }
}