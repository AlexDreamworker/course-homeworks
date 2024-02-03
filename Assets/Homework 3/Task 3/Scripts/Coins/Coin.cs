using System;
using UnityEngine;

namespace Homework3.Task3
{
    public abstract class Coin : MonoBehaviour
    {
        public event Action<Coin> Collected;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICoinPicker coinPicker))
            {
                AddCoins(coinPicker);

                Collected?.Invoke(this);

                Destroy(gameObject);
            }
        }

        protected abstract void AddCoins(ICoinPicker coinPicker);

        public void SetPosition(Vector3 position) => transform.position = position;
    }
}