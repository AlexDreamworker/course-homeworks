using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Homework1.Task4 
{
    public class DestroyConcreteColor : IVictoryCondition
    {
        private ColorType _targetColor;

        public DestroyConcreteColor(ColorType type) 
        {
            _targetColor = type;
        }

        public bool CheckCondition(List<Ball> balls)
        {
            bool result = false;

            var targetBalls = balls.Where(ball => ball.IsActive && ball.ColorType == _targetColor);
            var otherBalls = balls.Where(ball => ball.IsActive == false && ball.ColorType != _targetColor);

            if (otherBalls.Count() > 0) 
            {
                Debug.Log("<color=red>You destroy wrong ball! Try again...</color>");
                result = false;
            }
            else if (targetBalls.Count() == 0 && otherBalls.Count() == 0) 
            {
                result = true;
            }

            return result;
        }
    }
}