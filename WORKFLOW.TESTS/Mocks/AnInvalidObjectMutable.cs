using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS.Mocks
{
    class AnInvalidObjectMutable : IMutable
    {
        public IStep State { get; set; }

        public void SetState(dynamic state)
        {
            this.State = state;
        }
    }
}
