using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework4.Task3
{
    public class DestroyAll : GameMode
    {   
        public override event Action Completed;
        public override event Action Failed;

        public DestroyAll(List<Ball> balls) : base(balls) { }

        protected override void CheckCondition(IReadOnlyBall ball)
        {
            if (_balls.All(ball => ball.IsActive == false)) 
                Completed?.Invoke();
        }
    }
}