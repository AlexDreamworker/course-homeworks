using System;
using UnityEngine;

namespace Homework3.Task4
{
    public abstract class Enemy : MonoBehaviour
    {
        public event Action<Enemy> Died;

        public void MoveTo(Vector3 position) => transform.position = position;

        public void Kill()
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}