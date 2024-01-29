using System;
using UnityEngine;

namespace Homework1.Task2 
{
    public class InputReader
    {
        public event Action PreviousWeaponChanged;
        public event Action NextWeaponChanged;
        public event Action ShootButtonChanged;

        private readonly string _mouseScrollWheelKey = "Mouse ScrollWheel";

        public void UpdateUserInput()
        {
            if (Input.GetAxis(_mouseScrollWheelKey) < 0f)
                NextWeaponChanged?.Invoke();

            if (Input.GetAxis(_mouseScrollWheelKey) > 0f) 
                PreviousWeaponChanged?.Invoke();

            if (Input.GetMouseButtonDown(0))
                ShootButtonChanged?.Invoke();
        }
    }
}