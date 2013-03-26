using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    class AnExampleFlow : IFlow
    {

        IStep IFlow.Current
        {
            get
            {
                return new AState();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        IStep IFlow.Next
        {
            get
            {
                return new AnotherState();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        IStep IFlow.Previous
        {
            get
            {
                return new AState();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
