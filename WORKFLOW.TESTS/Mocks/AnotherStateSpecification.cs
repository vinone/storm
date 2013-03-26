using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    class AnotherStateSpecification : IStepSpecification
    {
        public bool IsValidForMoveForward()
        {
            return true;
        }

        public bool IsValidForMoveBackward()
        {
            throw new NotImplementedException();
        }
    }
}
