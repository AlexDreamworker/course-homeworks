using System;
using UnityEngine;

namespace Homework3.Task4
{
    public class Score: IDisposable
    {
        private IEnemyLifetimeNotifier _enemyLifetimeNotifier;

        private EnemyVisitor _enemyVisitor;

        public int Value => _enemyVisitor.Score;

        public Score(IEnemyLifetimeNotifier enemyLifetimeNotifier, ScoreConfig scoreConfig)
        {
            _enemyLifetimeNotifier = enemyLifetimeNotifier;
            _enemyLifetimeNotifier.DeathNotified += OnEnemyKilled;

            _enemyVisitor = new EnemyVisitor(scoreConfig);
        }

        public void Dispose() => _enemyLifetimeNotifier.DeathNotified -= OnEnemyKilled;

        private void OnEnemyKilled(Enemy enemy)
        {
            _enemyVisitor.Visit(enemy);

            Debug.Log($"Score: {Value}");
        }

        private class EnemyVisitor : IEnemyVisitor
        {
            private ScoreConfig _config;

            public int Score { get; private set; }

            public EnemyVisitor(ScoreConfig config) => _config = config;

            public void Visit(Ork ork) => Score += _config.Ork;

            public void Visit(Human human) => Score += _config.Human;

            public void Visit(Elf elf) => Score += _config.Elf;

            public void Visit(Robot robot) => Score += _config.Robot;

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);
        }
    }
}