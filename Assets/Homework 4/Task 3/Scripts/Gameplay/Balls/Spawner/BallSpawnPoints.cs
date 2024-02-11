using System.Collections.Generic;
using UnityEngine;

namespace Homework4.Task3
{
    public class BallSpawnPoints : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points = new List<Transform>();

        public IReadOnlyList<Transform> Points => _points;
    }
}