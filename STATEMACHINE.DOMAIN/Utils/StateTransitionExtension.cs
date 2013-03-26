using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STATEMACHINE.SKELETON;

namespace STATEMACHINE.DOMAIN.Utils
{
    public static class StateTransitionExtension
    {
        public static bool CanIProceed(this IStateTransition transition)
        {
            return transition.Target.Specification.IsValidForMoveForward();
        }
    }
}
