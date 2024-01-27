using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Homework2.Task2
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Worker : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private WorkerStateMachine _stateMachine;
        private Dictionary<DestinationType, Vector3> _destinationsMap;

        public Dictionary<DestinationType, Vector3> DestinationsMap => _destinationsMap;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;

        public void Initialize(Dictionary<DestinationType, Vector3> destinationMap) 
        {
            _destinationsMap = destinationMap;

            _stateMachine = new WorkerStateMachine(this);
        }

        private void OnValidate()
        {
            _navMeshAgent ??= GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}