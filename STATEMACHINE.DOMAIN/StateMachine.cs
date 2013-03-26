using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STATEMACHINE.SKELETON;
using STATEMACHINE.DOMAIN.Utils;

namespace STATEMACHINE.DOMAIN
{
    public class StateMachine : IStateMachine
    {
        public StateMachine()
        {
            //Horrível!
            //Os estados devem ser configurados em algum lugar
            this.States = new List<IStateMachineState>();
        }

        public StateMachine(string name)
        {
            Name = name;
        }

        public int Identifier { get; protected set; }

        public string Name { get; protected set; }

        public IList<IStateMachineState> States { get; protected set; }

        private IStateMachineState _currentState;
        public IStateMachineState CurrentState
        {
            get { return _currentState; }
            protected set { _currentState = value; }
        }

        public void Start()
        {
            if (IsStarted)
                return;

            if (States.IsEmpty())
                CurrentState = States.Default();
        }

        public void PerformTransition(IStateTransition transition)
        {
            if (transition.Parent.Specification.IsValidForMoveForward())
                SetState(transition.Target);
        }

        private IStateTransitionPendingQueue _transitionsPending;
        public IStateTransitionPendingQueue TransitionsPending
        {
            get
            {
                if (_transitionsPending == null)
                    _transitionsPending = new StateTransitionPendingQueue();

                return _transitionsPending;
            }
        }

        private void SetState(IStateMachineState targetState)
        {
            targetState.TestForArgumentNull();

            this.CurrentState = targetState;
        }

        public bool IsStarted
        {
            get { return CurrentState != null; }
        }
    }
}
