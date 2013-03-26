using STATEMACHINE.SKELETON;

namespace STATEMACHINE.DOMAIN
{
    public class PendencyController
    {
        public static void VerifyPendency(IStateTransitionPending transitionToVerify)
        {
            if (AlreadyApproved(transitionToVerify))
                transitionToVerify.StateMachine
                    .TransitionsPending
                    .TakeAway(transitionToVerify);

            if (ICannotApprove(transitionToVerify))
                transitionToVerify.StateMachine
                    .TransitionsPending
                    .PutNew(transitionToVerify);
        }

        private static bool AlreadyApproved(IStateTransitionPending transitionToVerify)
        {
            return transitionToVerify.TransitionPending.Policy.IsApproved;
        }

        private static bool ICannotApprove(IStateTransitionPending transitionToVerify)
        {
            return !transitionToVerify.TransitionPending.Policy.CanIApprove;
        }
    }
}
