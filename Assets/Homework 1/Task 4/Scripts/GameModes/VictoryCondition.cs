using System;
using System.Collections.Generic;

namespace Homework1.Task4 
{
    public abstract class VictoryCondition : IDisposable
    {
        public abstract event Action Completed;

        protected List<Ball> _balls; 

        public VictoryCondition(List<Ball> balls) 
        {
            _balls = balls;

            foreach (Ball ball in _balls)
                ball.BallDisabled += CheckCondition;

            ActivateAllBalls();
        }

        public void Dispose()
        {
            foreach (Ball ball in _balls)
                ball.BallDisabled -= CheckCondition;
        }

        protected abstract void CheckCondition(IReadOnlyBall ball);

        private void ActivateAllBalls() 
        {
            foreach (Ball ball in _balls)
                ball.Activate();
        }
    }
}