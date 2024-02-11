using System;
using UnityEngine;
using Zenject;

namespace Homework4.Task3
{
    public class InputReader : ITickable
    {
        public event Action MouseClicked;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
                MouseClicked?.Invoke();
        }
    }
}