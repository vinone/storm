
namespace STATEMACHINE.SKELETON
{
    public interface ICustomStateMachineControllerContext
    {
        IStateMachine ControledMachine { get; }
        void Release();
    }
}
