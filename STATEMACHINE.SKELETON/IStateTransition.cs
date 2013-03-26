using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STATEMACHINE.SKELETON
{
    public interface IStateTransition
    {
        int Identifier { get; set; }
        string Name { get; set; }
        IStateMachineState Parent { get; set; }
        IStateMachineState Target { get; set; }
        IStateTransitionPolicy Policy { get; set; }
    }
}
