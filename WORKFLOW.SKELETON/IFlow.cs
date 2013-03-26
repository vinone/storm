
namespace WORKFLOW.SKELETON
{
    public interface IFlow
    {
        IStep Current{get; set;}
        IStep Next{get; set;}
        IStep Previous{get; set;}
    }
}
