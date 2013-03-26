using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STATEMACHINE.SKELETON;
using STATEMACHINE.DOMAIN.Utils;

namespace STATEMACHINE.DOMAIN
{
    public class StateTransition : IStateTransition
    {
        public StateTransition(IStateMachineState parent, IStateMachineState target)
        {
            this.Parent = parent;
            this.Target = target;
        }

        protected StateTransition(){}

        public int Identifier { get; set; }

        public string Name { get; set; }

        private IStateMachineState _parent;
        public IStateMachineState Parent
        {
            get { return _parent; }
            set
            {
                value.TestForArgumentNull();
                _parent = value;
            }
        }

        private IStateMachineState _target;
        public IStateMachineState Target
        {
            get 
            { 
                return _target; 
            }
            set
            {
                value.TestForArgumentNull();
                _target = value;
            }
        }

        private IStateTransitionPolicy _policy;
        public IStateTransitionPolicy Policy
        {
            get 
            {
                if (_policy == null)
                    Policy = NullStateTransitionPolicy.NewNullObject;

                return _policy;
            }
            set
            { _policy = value; }
        }
    }
}
