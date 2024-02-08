using UnityEngine;

namespace Homework4.Task1
{
    public interface IEnemyTarget : IDamageable
    {
        Vector3 Position { get; }
    }
}