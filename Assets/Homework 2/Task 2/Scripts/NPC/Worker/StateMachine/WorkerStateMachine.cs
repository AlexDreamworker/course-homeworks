using System.Collections.Generic;
using System.Linq;

namespace Homework2.Task2
{
    public class WorkerStateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState;

        public WorkerStateMachine(Worker worker) 
        {
            WorkerStateMachineData data = new WorkerStateMachineData();

            _states = new List<IState>() 
            {
                new MovementState(this, data, worker),
                new WorkingState(this, data),
                new RestingState(this, data)
            };

            _currentState = _states[2];
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);

            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update() => _currentState.Update();
    }
}