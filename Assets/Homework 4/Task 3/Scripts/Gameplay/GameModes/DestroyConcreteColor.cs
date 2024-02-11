using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework4.Task3
{
    public class DestroyConcreteColor : GameMode
    {
        public override event Action Completed;
        public override event Action Failed;

        private ColorType _targetColor;

        public DestroyConcreteColor(List<Ball> balls, ColorType type) : base(balls)  
            => _targetColor = type;

        protected override void CheckCondition(IReadOnlyBall ball)
        {
            if (ball.ColorType != _targetColor) 
            {          
                Failed?.Invoke();
                return;
            }

            var targetBalls = _balls.Where(ball => ball.IsActive && ball.ColorType == _targetColor);

            if (targetBalls.Count() == 0)
                Completed?.Invoke();
        }
    }
}