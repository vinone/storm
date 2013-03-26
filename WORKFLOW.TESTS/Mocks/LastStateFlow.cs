using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    class LastStateFlow : IFlow
    {
        public IStep Current
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

        public IStep Next
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IStep Previous
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
