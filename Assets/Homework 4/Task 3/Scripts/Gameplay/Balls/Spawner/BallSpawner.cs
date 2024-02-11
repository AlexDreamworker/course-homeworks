using Zenject;

namespace Homework4.Task3
{
    public class BallSpawner
    {
        private BallSpawnPoints _points;
        private BallFactory _ballFactory;
        private BallsList _ballsList;

        [Inject]
        private void Construct(BallFactory ballFactory, BallSpawnPoints points, BallsList ballsList)
        {
            _ballFactory = ballFactory;
            _points = points;
            _ballsList = ballsList;
        }

        public void Start()
        {
            for (int i = 0; i < _points.Points.Count; i++) 
            {
                Ball ball = _ballFactory.Get();
                ball.MoveTo(_points.Points[i].position);

                _ballsList.Add(ball);
            }
        }

        public void Stop() => _ballsList.Clean();
    }
}