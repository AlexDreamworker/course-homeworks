using System;
using UnityEngine;
using Zenject;

namespace Homework4.Task2
{
    public class Level  : IInitializable
    {
        public event Action Defeat;

        private IInput _input;

        [Inject]
        private void Construct(IInput input) 
        {
            _input = input;
        }

        public void Initialize() => Start();

        public void Start()
        {
            //* Start logic
            Debug.Log("Level: Start");

            _input.DefeatButtonPressed += OnDefeat;
        }

        public void Restart()
        {
            //* Level cleanup logic
            Debug.Log("Level: Restart");

            Start();
        }

        public void OnDefeat()
        {
            //* Stop game logic
            Debug.Log("Level: OnDefeat");

            _input.DefeatButtonPressed -= OnDefeat;

            Defeat?.Invoke();
        }
    }
}