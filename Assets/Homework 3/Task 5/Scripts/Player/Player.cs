using UnityEngine;

namespace Homework3.Task5
{
    public class Player
    {
        private IStatsProvider _statsProvider;

        public Player(IStatsProvider statsProvider) 
        {
            _statsProvider = statsProvider;

            PrintStats();
        }

        public void PrintStats() 
        {
            Debug.Log($"Strength is: {_statsProvider.GetStats().Strength}");
            Debug.Log($"Agility is: {_statsProvider.GetStats().Agility}");
            Debug.Log($"Intelligence is: {_statsProvider.GetStats().Intelligence}");
        }
    }
}