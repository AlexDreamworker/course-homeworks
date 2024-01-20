using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework1.Task4 
{
    public class DestroyAll : VictoryCondition
    {   
        public DestroyAll(List<Ball> balls) : base(balls) { }

        public override event Action Completed;

        protected override void CheckCondition(IReadOnlyBall ball)
        {
            if (_balls.All(ball => ball.IsActive == false)) 
                Completed?.Invoke();
        }
    }
}