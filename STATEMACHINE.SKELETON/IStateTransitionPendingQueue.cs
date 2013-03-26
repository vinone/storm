using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STATEMACHINE.SKELETON
{
    public interface IStateTransitionPendingQueue
    {
        IEnumerable<IStateTransitionPending> MyPendencies { get; }
        void PutNew(IStateTransitionPending transition);
        IStateTransitionPending Find(Func<IStateTransitionPending, bool> expression);
        int Count { get; }
        void TakeAway(IStateTransitionPending transition);
        bool HaveAnyEquals(IStateTransitionPending transition);
    }
}
