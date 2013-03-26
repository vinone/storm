using System.Collections.Generic;
using STATEMACHINE.SKELETON;

namespace STATEMACHINE.DOMAIN
{
    public interface IStateMachineRepository
    {
        IStateMachine GetStateMachineByIdentifier(int identifier);
        IList<IStateMachineState> GetAllStatesFromAStateMachine(IStateMachine stateMachine);
        IStateTransitionPolicy GetPolicyByStateTransition(IStateTransition transition);
        IList<IStateTransition> GetAllPendencies(IStateMachine stateMachine);
    }
}
