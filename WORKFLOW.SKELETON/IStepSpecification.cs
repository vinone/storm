
namespace WORKFLOW.SKELETON
{
    public interface IStepSpecification
    {
        bool IsValidForMoveForward();
        bool IsValidForMoveBackward();
    }
}
