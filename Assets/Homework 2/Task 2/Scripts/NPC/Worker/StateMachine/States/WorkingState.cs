using UnityEngine;

namespace Homework2.Task2
{
    public class WorkingState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly WorkerStateMachineData _data;

        private float _timeRemaining;

        private const float TIMER_DURATION = 3f;

        public WorkingState(IStateSwitcher stateSwitcher, WorkerStateMachineData data) 
        {
            _stateSwitcher = stateSwitcher;
            _data = data;
        }

        public void Enter()
        {
            Debug.Log("<color=red>Working started</color>");

            _timeRemaining = TIMER_DURATION;
        }

        public void Exit() 
        { 
            Debug.Log("<color=red>Working finished</color>");

            _data.Destination = DestinationType.Home;
        }

        public void Update() 
        {
            Debug.Log("<color=red>Work in process</color>");

            while (_timeRemaining > 0) 
            {
                _timeRemaining -= Time.deltaTime;            
                return;
            }

            _stateSwitcher.SwitchState<MovementState>();
        }
    }
}