
namespace STATEMACHINE.SKELETON
{
    public interface IStateTransitionPending
    {
        int Identifier { get; }
        IStateMachine StateMachine { get; }
        IStateTransition TransitionPending { get; }
    }
}
