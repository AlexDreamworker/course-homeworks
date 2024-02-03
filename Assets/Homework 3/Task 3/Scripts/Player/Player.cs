using System;
using UnityEngine;

namespace Homework3.Task3
{
    public class Player : MonoBehaviour, ICoinPicker
    {
        public int Coins { get; private set; }

        public void Add(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException($"{value} less than 0!");

            Coins += value;
            Debug.Log(Coins);
        }
    }
}