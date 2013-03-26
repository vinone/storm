using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STATEMACHINE.SKELETON
{
    public interface ICredentialProvider
    {
        ICredential ProvideCredential();
    }
}
