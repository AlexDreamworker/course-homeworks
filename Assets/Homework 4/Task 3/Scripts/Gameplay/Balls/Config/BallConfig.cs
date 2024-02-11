using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework4.Task3
{
    [CreateAssetMenu(fileName = "BallConfig", menuName = "HW4-T3/Configs/BallConfig")]
    public class BallConfig : ScriptableObject
    {
        [SerializeField] private List<Ball> _balls = new List<Ball>();

        public Ball RandomPrefab => _balls[Random.Range(0, _balls.Count)];
    }
}