using System.Collections.Generic;
using UnityEngine;

namespace Homework1.Task4
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private List<Ball> _balls = new List<Ball>();

        private GameMode _gameMode = new GameMode();

        private void Awake() 
        {
            _gameMode.SetVictoryCondition(new DestroyAll());

            Debug.Log("Game Mode is: Destroy All!");
        }

        private void Update()
        {
            if (_gameMode.VictoryCondition.CheckCondition(_balls))
                Debug.Log("<color=green>VICTORY!!!</color>");
        }

        public void SetGameModeDestroyAll() 
        {
            _gameMode.SetVictoryCondition(new DestroyAll());
            RestartGame();
        }

        public void SetGameModeDestroyConcreteColor(ColorType colorType) 
        {
            _gameMode.SetVictoryCondition(new DestroyConcreteColor(colorType));
            RestartGame();
        }

        public void RestartGame() 
        {
            foreach (Ball ball in _balls)
                ball.Activate();
        }
    }
}