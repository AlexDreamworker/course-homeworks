using System;
using UnityEngine;

namespace Homework4.Task3
{
    public class Ball : MonoBehaviour, IReadOnlyBall
    {
        public event Action<IReadOnlyBall> BallDisabled;

        [SerializeField] private ColorType _colorType;

        public Ball IReadOnlyBall => this;
        public ColorType ColorType => _colorType;
        public bool IsActive => gameObject.activeSelf;

        private void Start() => Activate();

        public void MoveTo(Vector3 position) => transform.position = position;

        public void Activate() => gameObject.SetActive(true);
        
        public void Deactivate()
        {
            gameObject.SetActive(false);

            BallDisabled?.Invoke(this);
        }

        public void Kill() => Destroy(gameObject);
    }
}