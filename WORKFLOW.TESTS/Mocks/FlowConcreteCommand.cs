using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    public abstract class FlowCommand
    {
        public abstract void Execute();

        protected IFlowImplementation implementation;

        public FlowCommand(IFlowImplementation implementation)
        {
            this.implementation = implementation;
        }
    }

    public class FlowMonitoramentoCommand : FlowCommand
    {
        public FlowMonitoramentoCommand(IFlowImplementation implementation)
            : base(implementation)
        {}

        public override void Execute()
        {
            implementation.Execute();
        }

    }

    public class FlowMoveForwardImplementation : IFlowImplementation
    {
        private IStepSpecification _specification;

        public FlowMoveForwardImplementation(IStepSpecification specification)
        {
            this._specification = specification;
        }

        public void Execute()
        {
            if(_specification.IsValidForMoveForward())
 	            throw new Exception("MoveForwardCommand");
        }
    }

    public class FlowMoveBackwardImplementation : IFlowImplementation
    {
        private IStepSpecification _specification;

        public FlowMoveBackwardImplementation(IStepSpecification specification)
        {
            this._specification = specification;
        }

        public void Execute()
        {
            if(_specification.IsValidForMoveBackward())
                throw new Exception("MoveBackwardCommand");
        }
    }

    public interface IFlowImplementation
    {
        void Execute();
    }

    public class ExampleFlowController
    {
        private FlowCommand _command;

        public void SetCommand(FlowCommand command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            this._command.Execute();
        }
    }
}
