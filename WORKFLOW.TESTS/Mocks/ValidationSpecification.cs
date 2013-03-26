using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    class ValidationSpecification : IStepSpecification
    {
        public bool IsValidForMoveForward()
        {
            return false;
        }

        public bool IsValidForMoveBackward()
        {
            throw new NotImplementedException();
        }
    }
}
