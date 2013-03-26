using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;

namespace STATEMACHINE.SKELETON
{
    public interface IStateMachineState
    {
        string Name { get; }
        IList<IStateTransition> Transitions { get; }
        IStepSpecification Specification { get; }
    }
}
