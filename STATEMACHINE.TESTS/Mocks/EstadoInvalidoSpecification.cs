using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;

namespace STATEMACHINE.TESTS.Mocks
{
    internal class EstadoInvalidoSpecification : IStepSpecification
    {
        public bool IsValidForMoveForward()
        {
            return false;
        }

        public bool IsValidForMoveBackward()
        {
            return false;
        }
    }
}
