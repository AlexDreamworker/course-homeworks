using System.Collections.Generic;

namespace Homework4.Task3
{
    public class BallsList
    {
        private List<Ball> _balls = new List<Ball>();

        public List<Ball> Balls => _balls;

        public void Add(Ball ball) => _balls.Add(ball);

        public void Clean() 
        {
            for (int i = 0; i < _balls.Count ; i++)
                _balls[i].Kill();

            _balls.Clear();
        }
    }
}