using System;
using UnityEngine;

namespace Homework3.Task4
{
    public class Weight : IDisposable
    {
        private int _max = 100;

        private IEnemyLifetimeNotifier _enemyLifetimeNotifier;

        private EnemyVisitor _enemyVisitor;

        public int Value => _enemyVisitor.Weight;

        public Weight(IEnemyLifetimeNotifier enemyLifetimeNotifier, WeightConfig config) 
        {
            _enemyLifetimeNotifier = enemyLifetimeNotifier;

            _enemyLifetimeNotifier.DeathNotified += OnEnemyKilled;
            _enemyLifetimeNotifier.CreateNotified += OnEnemyCreated;

            _enemyVisitor = new EnemyVisitor(config);
        }

        public void Dispose() 
        {
            _enemyLifetimeNotifier.DeathNotified -= OnEnemyKilled;
            _enemyLifetimeNotifier.CreateNotified -= OnEnemyCreated;
        }

        public bool IsLimit() 
        {
            return Value >= _max;
        }

        private void OnEnemyCreated(Enemy enemy) 
        {
            _enemyVisitor.SwitchCalculatingMode(true);
            _enemyVisitor.Visit(enemy);

            Debug.Log($"Weight: {Value}");
        }

        private void OnEnemyKilled(Enemy enemy)
        {
            _enemyVisitor.SwitchCalculatingMode(false);
            _enemyVisitor.Visit(enemy);

            Debug.Log($"Weight: {Value}");
        }

        private class EnemyVisitor : IEnemyVisitor
        {
            private WeightConfig _config;

            public int Weight { get; private set; }
            public bool IsIncrease { get; private set; }

            public EnemyVisitor(WeightConfig config) => _config = config;

            public void Visit(Ork ork) => CalculateWeight(_config.Ork);

            public void Visit(Human human) => CalculateWeight(_config.Human);

            public void Visit(Elf elf) => CalculateWeight(_config.Elf);

            public void Visit(Robot robot) => CalculateWeight(_config.Robot);

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);

            public void SwitchCalculatingMode(bool isIncrease) => IsIncrease = isIncrease;

            private void CalculateWeight(int enemyWeight)
            {
                int currentWeight = IsIncrease ? enemyWeight : -enemyWeight;
                Weight += currentWeight;
            }
        }
    }
}