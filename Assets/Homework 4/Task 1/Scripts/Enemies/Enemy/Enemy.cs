using UnityEngine;
using Zenject;

namespace Homework4.Task1
{
    public class Enemy : MonoBehaviour
    {
        private int _health;
        private float _speed;

        private IEnemyTarget _target;

        [Inject]
        private void Construct(IEnemyTarget enemyTarget)
        {
            _target = enemyTarget;
        }

        public virtual void Initialize(int helath, float speed)
        {
            _health = helath;
            _speed = speed;
        }

        private void Update()
        {
            Vector3 direction = (_target.Position - transform.position).normalized;
            transform.Translate(direction * _speed * Time.deltaTime);
        }

        public void MoveTo(Vector3 position) => transform.position = position;
    }
}