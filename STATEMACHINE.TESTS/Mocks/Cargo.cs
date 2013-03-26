using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STATEMACHINE.SKELETON;

namespace STATEMACHINE.TESTS.Mocks
{
    public class Cargo : ICredential
    {
        public string GetDescription()
        {
            return "Aprovador";
        }
    }
}
