using UnityEngine;

namespace Homework1.Task3 
{
    public class TradeFruitsStrategy : ITradeStrategy
    {
        public void StartTrading()
        {
            Debug.Log("<color=yellow>Trader:</color> Oh, dear <color=green>ELF</color>, would you like to buy some <color=green>FRUITS</color>?");
        }

        public void StopTrading()
        {
            Debug.Log("<color=yellow>Trader:</color> Bye!");
        }
    }
}