using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    class AnotherExampleFlow : IFlow
    {
        IStep IFlow.Current
        {
            get
            {
                return new AValidationState();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IStep IFlow.Next
        {
            get
            {
                return new AValidationState();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IStep IFlow.Previous
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
