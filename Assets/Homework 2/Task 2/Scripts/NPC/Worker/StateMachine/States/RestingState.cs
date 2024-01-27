using UnityEngine;

namespace Homework2.Task2
{
    public class RestingState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly WorkerStateMachineData _data;

        private float _timeRemaining = 0f; 
        
        private const float TIMER_DURATION = 3f;

        public RestingState(IStateSwitcher stateSwitcher, WorkerStateMachineData data) 
        {
            _stateSwitcher = stateSwitcher;
            _data = data;
        }

        public void Enter()
        {
            Debug.Log("<color=green>Resting started</color>");

            _timeRemaining = TIMER_DURATION;
        }

        public void Exit() 
        { 
            Debug.Log("<color=green>Resting finished</color>");

            _data.Destination = DestinationType.Work;
        }

        public void Update() 
        {
            Debug.Log("<color=green>Rest in process</color>");

            while (_timeRemaining > 0) 
            {
                _timeRemaining -= Time.deltaTime;            
                return;
            }

            _stateSwitcher.SwitchState<MovementState>();
        }
    }
}