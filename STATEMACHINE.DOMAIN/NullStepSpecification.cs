using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WORKFLOW.SKELETON;
using STATEMACHINE.SKELETON;
using STATEMACHINE.DOMAIN.Utils;

namespace STATEMACHINE.DOMAIN
{
    public class NullStepSpecification : IStepSpecification
    {
        public bool IsValidForMoveForward()
        {
            return true;
        }

        public bool IsValidForMoveBackward()
        {
            return true;
        }

        public static IStepSpecification NewNullObject
        {
            get { return new NullStepSpecification(); }
        }
    }
}
