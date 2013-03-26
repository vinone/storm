using STATEMACHINE.DOMAIN.Utils;
using STATEMACHINE.SKELETON;

namespace STATEMACHINE.DOMAIN
{
    public class StateTransitionPolicy : IStateTransitionPolicy
    {
        public StateTransitionPolicy(ICredential credentialToApprove)
        {
            if(this.CredentialToApprove == null)
                this.CredentialToApprove = credentialToApprove;
        }

        private ICredential _credentialToApprove;
        public ICredential CredentialToApprove
        {
            get { return _credentialToApprove; }
            protected set { _credentialToApprove = value; }
        }

        private ICredential _credentialProvided;
        public ICredential CredentialProvided 
        {
            get { return _credentialProvided; }
        }

        public int Identifier { get; protected set; }

        public string Name { get; set; }

        public void Approve()
        {
            if (CredentialProvided == null)
                return;

            _isApproved = true;
        }

        private bool _isApproved;
        public bool IsApproved
        {
            get 
            {
                return _isApproved;
            }
        }

        public virtual bool CanIApprove
        {
            get 
            {
                return _credentialToApprove.GetDescription() == CredentialProvided.GetDescription();
            }
        }

        public void SetCredential(ICredential credential)
        {
            credential.TestForArgumentNull();
            _credentialProvided = credential;
        }
    }
}
