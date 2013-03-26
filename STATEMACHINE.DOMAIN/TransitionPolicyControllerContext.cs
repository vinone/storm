using STATEMACHINE.SKELETON;
using STATEMACHINE.DOMAIN.Utils;

namespace STATEMACHINE.DOMAIN
{
    public class TransitionPolicyControllerContext : ICustomStateMachineControllerContext
    {
        public TransitionPolicyControllerContext(IStateMachine stateMachine, IStateTransition currentTransition, ICredential credentialToApprov)
        {
            stateMachine.TestForArgumentNull();
            ControledMachine = stateMachine;

            currentTransition.TestForArgumentNull();
            _currentTransition = currentTransition;

            credentialToApprov.TestForArgumentNull();
            _credentialToApprov = credentialToApprov;
        }

        private IStateTransition _currentTransition;
        private ICredential _credentialToApprov;
        private PendencyController _pendencyController;

        private IStateMachine _controledMachine;
        public IStateMachine ControledMachine
        {
            get { return _controledMachine; }
            private set { _controledMachine = value; }
        }

        public void Release()
        {
            if (!_controledMachine.IsStarted)
                return;

            _currentTransition.Policy.SetCredential(_credentialToApprov);

            if (_currentTransition.Policy.CanIApprove)
            {
                _currentTransition.Policy.Approve();
                _controledMachine.PerformTransition(_currentTransition);
            }

            PendencyController.VerifyPendency(new StateTransitionPending(ControledMachine, _currentTransition));
        }
    }
}
