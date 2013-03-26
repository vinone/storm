using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STATEMACHINE.SKELETON;
using WORKFLOW.SKELETON;

namespace STATEMACHINE.DOMAIN
{
    public class StateMachineState : IStateMachineState
    {
        public StateMachineState(string name)
        {
            this.Name = name;

            Initialize();
        }

        public StateMachineState(string name, IStepSpecification specification)
        {
            this.Name = name;
            this.Specification = specification;

            Initialize();
        }

        private void Initialize()
        {
            Transitions = new List<IStateTransition>();
        }

        public string Name { get; protected set; }

        public IList<IStateTransition> Transitions { get; protected set; }

        private IStepSpecification _specification;
        public IStepSpecification Specification
        {
            get 
            {
                if(_specification == null)
                    Specification = NullStepSpecification.NewNullObject;

                return _specification; 
            }
            protected set { _specification = value; }
        }
    }
}
