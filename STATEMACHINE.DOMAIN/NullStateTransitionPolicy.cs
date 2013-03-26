using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STATEMACHINE.DOMAIN.Utils;
using STATEMACHINE.SKELETON;

namespace STATEMACHINE.DOMAIN
{
    public class NullStateTransitionPolicy : IStateTransitionPolicy
    {
        public bool CanIApprove
        {
            get { return true; }
        }

        public ICredential CredentialToApprove
        {
            get { return null; }
        }

        public ICredential CredentialProvided
        {
            get { return null; }
        }

        public void SetCredential(ICredential credential)
        {
            return;
        }

        public void Approve()
        {
            return;
        }

        public bool IsApproved
        {
            get { return true; }
        }

        public int Identifier { get { return 0; } }

        public string Name { get { return "NullPolicy"; } set { return; } }

        public static IStateTransitionPolicy NewNullObject
        {
            get { return new NullStateTransitionPolicy(); }
        }
    }
}
