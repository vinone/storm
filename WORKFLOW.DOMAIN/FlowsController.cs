using WORKFLOW.SKELETON;

namespace WORKFLOW.DOMAIN
{
    public class FlowsController : IFlowsController
    {
        private IMutable _mutable;
        private IFlow _flow;

        public FlowsController(IMutable mutable, IFlow flow)
        {
            this._mutable = mutable;
            this._flow = flow;
        }

        public void MoveForward()
        {
            var nextStep = this._flow.Next;

            if (nextStep == null) return;

            var stepSpecification = nextStep.GetStepSpecification();

            if (stepSpecification.IsValidForMoveForward())
                this._mutable.SetState(nextStep);
        }

        public void MoveBackward()
        {
            var previousStep = this._flow.Previous;

            if (previousStep == null) return;

            var stepSpecification = previousStep.GetStepSpecification();

            if (stepSpecification.IsValidForMoveBackward())
                this._mutable.SetState(previousStep);
        }

        public IMutable GetCurrent()
        {
            return this._mutable;
        }
    }
}
