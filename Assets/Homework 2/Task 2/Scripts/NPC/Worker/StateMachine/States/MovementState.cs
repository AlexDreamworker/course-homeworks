using UnityEngine;
using UnityEngine.AI;

namespace Homework2.Task2
{
    public class MovementState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly Worker _worker;
        private readonly WorkerStateMachineData _data;

        private NavMeshAgent NavMesh => _worker.NavMeshAgent;

        public MovementState(IStateSwitcher stateSwitcher, WorkerStateMachineData data, Worker worker) 
        {
            _stateSwitcher = stateSwitcher;
            _data = data;
            _worker = worker;
        }

        public void Enter()
        {
            Debug.Log("<color=yellow>Moving started</color>");

            NavMesh.destination = _worker.DestinationsMap[_data.Destination];
        }

        public void Exit() 
        {
            Debug.Log("<color=yellow>Moving finished</color>");
        }

        public void Update() 
        {
            Debug.Log("<color=yellow>Movement in process</color>");

            if (DestinationReached() == false)
                return;

            if (_data.Destination == DestinationType.Home)
                _stateSwitcher.SwitchState<RestingState>();

            if (_data.Destination == DestinationType.Work)
                _stateSwitcher.SwitchState<WorkingState>();
        }

        public bool DestinationReached()
        {
            if (NavMesh.pathPending == false)
                if (NavMesh.remainingDistance <= NavMesh.stoppingDistance)
                    if (NavMesh.hasPath == false || NavMesh.velocity.sqrMagnitude == 0f)
                        return true;

            return false;
        }
    }
}