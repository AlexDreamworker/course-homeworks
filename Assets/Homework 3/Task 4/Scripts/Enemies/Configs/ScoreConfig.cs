using System;
using UnityEngine;

namespace Homework3.Task4
{
    [Serializable]
    public class ScoreConfig
    {
        [SerializeField, Range(0, 100)] private int _human = 20;
        [SerializeField, Range(0, 100)] private int _ork = 5;
        [SerializeField, Range(0, 100)] private int _elf = 10;
        [SerializeField, Range(0, 100)] private int _robot = 15;

        public int Human => _human;
        public int Ork => _ork;
        public int Elf => _elf;
        public int Robot => _robot;
    }
}