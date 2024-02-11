using System;
using System.Collections.Generic;

namespace Homework4.Task3
{
    public abstract class GameMode : IDisposable
    {
        public abstract event Action Completed;
        public abstract event Action Failed;

        protected List<Ball> _balls; 

        public GameMode(List<Ball> balls) 
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