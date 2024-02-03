using System;
using UnityEngine;

namespace Homework3.Task4
{
    public class InputReader
    {
        public event Action KillButtonChanged;

        public void UpdateUserInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
                KillButtonChanged?.Invoke();
        }
    }
}