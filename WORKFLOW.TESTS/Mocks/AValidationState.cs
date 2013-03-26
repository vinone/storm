using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    class AValidationState : IStep
    {
        public IStepSpecification GetStepSpecification()
        {
            return new ValidationSpecification();
        }
    }
}
