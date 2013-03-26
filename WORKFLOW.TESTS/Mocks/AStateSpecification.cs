using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    class AStateSpecification : IStepSpecification
    {
        public bool IsValidForMoveForward()
        {
            return false;
        }

        public bool IsValidForMoveBackward()
        {
            return true;
        }
    }
}
