using System;
using UnityEngine;

namespace Homework3.Task4
{
    [Serializable]
    public class WeightConfig
    {
        [SerializeField, Range(0, 100)] private int _human = 15;
        [SerializeField, Range(0, 100)] private int _ork = 10;
        [SerializeField, Range(0, 100)] private int _elf = 10;
        [SerializeField, Range(0, 100)] private int _robot = 25;

        public int Human => _human;
        public int Ork => _ork;
        public int Elf => _elf;
        public int Robot => _robot;
    }
}