using System;
using UnityEngine;

namespace Homework1.Task4
{
    public class InputReader
    {
        public event Action MouseClicked;

        public void UpdateUserInput() 
        {
            if (Input.GetMouseButtonDown(0))
                MouseClicked?.Invoke();
        }
    }
}