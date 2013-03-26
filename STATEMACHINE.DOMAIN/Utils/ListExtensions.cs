using System.Collections.Generic;
using System.Linq;
using STATEMACHINE.SKELETON;

namespace STATEMACHINE.DOMAIN.Utils
{
    public static class ListExtensions
    {
        public static IStateMachineState Default(this IList<IStateMachineState> stateList)
        {
            return stateList.FirstOrDefault();
        }

        public static bool IsEmpty(this IList<IStateMachineState> stateList)
        {
            return stateList.Count() > 0;
        }
    }
}
