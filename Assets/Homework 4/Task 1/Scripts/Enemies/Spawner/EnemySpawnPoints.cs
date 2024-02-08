using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework4.Task1
{
    public class EnemySpawnPoints : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points = new List<Transform>();

        public Vector3 GetRandom() 
        {
            return _points[Random.Range(0, _points.Count)].position;
        }
    }
}