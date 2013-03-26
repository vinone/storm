
namespace WORKFLOW.SKELETON
{
    public interface IFlowsController
    {
        void MoveForward();
        void MoveBackward();
        IMutable GetCurrent();
    }
}
