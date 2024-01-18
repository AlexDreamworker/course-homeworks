using System;
using UnityEngine;
using UnityEngine.AI;

namespace Homework1.Task3 
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class Player : MonoBehaviour, IRace
    {
        public Action<RaceType> RaceChanged;

        private RaceType _race = RaceType.Goblin;

        private NavMeshAgent _navMeshAgent;
        private Camera _camera;

        private Ray Ray => _camera.ScreenPointToRay(Input.mousePosition);

        private void Awake()
        {
            _camera = Camera.main;
            _navMeshAgent = GetComponent<NavMeshAgent>();

            Debug.Log($"Player race is: {_race}");
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
                if (Physics.Raycast(Ray, out RaycastHit hit)) 
                    _navMeshAgent.destination = hit.point;
        }

        public void SetNewRace(RaceType newType)
        {
            if (_race == newType)
                return;

            _race = newType;
            RaceChanged?.Invoke(_race);

            Debug.Log($"Player race is: {_race}");
        }
    }
}