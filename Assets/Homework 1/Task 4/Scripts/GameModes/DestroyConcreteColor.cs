using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Homework1.Task4 
{
    public class DestroyConcreteColor : VictoryCondition
    {
        private ColorType _targetColor;

        private bool _isWrongColor = false;

        public DestroyConcreteColor(List<Ball> balls, ColorType type) : base(balls) 
        { 
            _targetColor = type;
        }

        public override event Action Completed;

        protected override void CheckCondition(IReadOnlyBall ball)
        {
            if (_isWrongColor)
                return;

            if (ball.ColorType != _targetColor) 
            {
                _isWrongColor = true;
                Debug.Log("<color=red>You destroy wrong ball! Try again...</color>");;
                return;
            }

            var targetBalls = _balls.Where(ball => ball.IsActive && ball.ColorType == _targetColor);

            if (targetBalls.Count() == 0)
                Completed?.Invoke();
        }
    }
}