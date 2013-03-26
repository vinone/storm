using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STATEMACHINE.SKELETON
{
    public interface IStateTransitionPolicy
    {
        int Identifier { get; }
        string Name { get; set; }
        ICredential CredentialToApprove { get; }
        ICredential CredentialProvided { get; }
        void SetCredential(ICredential credential);
        void Approve();
        bool CanIApprove { get; }
        bool IsApproved { get; }
    }
}
