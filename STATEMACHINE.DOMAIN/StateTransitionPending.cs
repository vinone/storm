using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STATEMACHINE.SKELETON;

namespace STATEMACHINE.DOMAIN
{
    public class StateTransitionPending : IStateTransitionPending
    {
        public StateTransitionPending(IStateMachine stateMachine, IStateTransition transitionPending)
        {
            StateMachine = stateMachine;
            TransitionPending = transitionPending;
        }

        public IStateMachine StateMachine { get; protected set; }
        public IStateTransition TransitionPending { get; protected set; }

        public int Identifier { get; protected set; }
    }
}
