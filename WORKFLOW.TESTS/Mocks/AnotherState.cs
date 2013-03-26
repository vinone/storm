using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    class AnotherState : IStep
    {
        public IStepSpecification GetStepSpecification()
        {
            return new AnotherStateSpecification();
        }
    }
}
