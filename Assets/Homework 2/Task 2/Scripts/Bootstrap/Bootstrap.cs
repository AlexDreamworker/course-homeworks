using System.Collections.Generic;
using UnityEngine;

namespace Homework2.Task2
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Worker _worker;

        [Space]
        [SerializeField] private Transform _home;
        [SerializeField] private Transform _work;

        private Dictionary<DestinationType, Vector3> _destinationsMap;

        private void Awake()
        {
            _destinationsMap = new Dictionary<DestinationType, Vector3>()
            {
                { DestinationType.Home, _home.position },
                { DestinationType.Work, _work.position }
            };
        }

        private void Start()
        {
            _worker.Initialize(_destinationsMap);
        }
    }
}