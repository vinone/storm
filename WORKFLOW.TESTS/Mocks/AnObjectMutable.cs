using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    class AnObjectMutable : IMutable
    {
        public IStep State { get; set; }
        public string Name { get; set; }

        public void SetState(dynamic state)
        {
            this.State = state;
        }
    }
}
