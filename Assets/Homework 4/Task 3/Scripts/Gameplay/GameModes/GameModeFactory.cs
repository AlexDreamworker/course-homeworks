using System;
using Zenject;
using Random = UnityEngine.Random;

namespace Homework4.Task3
{
    public class GameModeFactory
    {
        private BallsList _ballsList;

        [Inject]
        private void Construct(BallsList ballsList) 
            => _ballsList = ballsList;

        public GameMode Get(GameModeType type) 
        {
            switch (type) 
            {
                case GameModeType.DestroyAll:
                    return new DestroyAll(_ballsList.Balls);

                case GameModeType.DestroyConcreteColor:
                    return new DestroyConcreteColor(_ballsList.Balls, GetRandomColorType());

                default:
                    throw new ArgumentOutOfRangeException($"Unknown GameMode type: {type}");
            }
        }

        private ColorType GetRandomColorType() 
        {
            return (ColorType)Random.Range(0, Enum.GetValues(typeof(ColorType)).Length);
        }
    }
}