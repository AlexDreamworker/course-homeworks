using System;
using UnityEngine;

namespace Homework1.Task4 
{
    public class Level : IDisposable
    {
        private VictoryCondition _victoryCondition;

        public void SetVictoryCondition(VictoryCondition victoryCondition) 
        {
            _victoryCondition?.Dispose();

            _victoryCondition = victoryCondition;

            _victoryCondition.Completed += OnCompleted;
        }

        public void Dispose()
        {
            _victoryCondition.Completed -= OnCompleted;
        }

        private void OnCompleted() => Debug.Log("LEVEL COMPLETED!");
    }
}