using System;
using UnityEngine;
using Zenject;

namespace Homework4.Task2
{
    public class DesktopInput : IInput, ITickable
    {
        public event Action DefeatButtonPressed;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                DefeatButtonPressed?.Invoke();
        }
    }
}