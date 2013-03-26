using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    class AState : IStep
    {
        public IStepSpecification GetStepSpecification()
        {
            return new AStateSpecification();
        }
    }
}
