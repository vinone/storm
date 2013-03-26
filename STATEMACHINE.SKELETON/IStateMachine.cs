using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STATEMACHINE.SKELETON
{
    public interface IStateMachine
    {
        int Identifier { get; }
        string Name { get; }
        IList<IStateMachineState> States { get; }
        IStateMachineState CurrentState { get; }
        void Start();
        void PerformTransition(IStateTransition transition);
        IStateTransitionPendingQueue TransitionsPending { get; }
        bool IsStarted { get; }
    }
}
