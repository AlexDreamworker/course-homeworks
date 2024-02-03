using System;

namespace Homework3.Task4
{
    public interface IEnemyLifetimeNotifier
    {
        event Action<Enemy> CreateNotified;
        event Action<Enemy> DeathNotified;
    }
}