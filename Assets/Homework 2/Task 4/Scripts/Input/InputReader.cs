using System;
using UnityEngine;

namespace Homework2.Task4
{
    public class InputReader
    {
        public event Action LevelUpButtonChanged;
        public event Action DamageButtonChanged;

        public void UpdateUserInput()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                LevelUpButtonChanged?.Invoke();

            if (Input.GetKeyDown(KeyCode.W))
                DamageButtonChanged?.Invoke();
        }
    }
}