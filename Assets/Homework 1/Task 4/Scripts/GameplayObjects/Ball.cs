using System;
using UnityEngine;

namespace Homework1.Task4 
{
    public class Ball : MonoBehaviour, IReadOnlyBall
    {
        public event Action<IReadOnlyBall> BallDisabled;

        [SerializeField] private ColorType _colorType;

        public Ball IReadOnlyBall => this;
        public ColorType ColorType => _colorType;
        public bool IsActive => gameObject.activeSelf;

        private void Start() => Activate();

        public void Activate() => gameObject.SetActive(true);
        
        public void Deactivate()
        {
            gameObject.SetActive(false);

            BallDisabled?.Invoke(this);
        }
    }
}