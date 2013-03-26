using System;
using STATEMACHINE.SKELETON;
using System.Collections.Generic;
using System.Linq;

namespace STATEMACHINE.DOMAIN.Utils
{
    public static class SimpleValidationExtensions
    {
        public static void TestForArgumentNull(this object valueToTest)
        {
            if (valueToTest == null)
                throw new ArgumentNullException();
        }
    }
}
