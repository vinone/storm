using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STATEMACHINE.SKELETON;

namespace STATEMACHINE.DOMAIN
{
    public class StateTransitionPendingQueue : IStateTransitionPendingQueue
    {
        public StateTransitionPendingQueue()
        {
            _transitions = new List<IStateTransitionPending>();
        }

        private List<IStateTransitionPending> _transitions;

        public IEnumerable<IStateTransitionPending> MyPendencies
        {
            get { return _transitions; } 
        }

        public void PutNew(IStateTransitionPending transition)
        {
            if (!HaveAnyEquals(transition))
                this._transitions.Add(transition);
        }

        public IStateTransitionPending Find(Func<IStateTransitionPending, bool> expression)
        {
            return MyPendencies.FirstOrDefault(expression);
        }

        public void TakeAway(IStateTransitionPending transition)
        {
            _transitions.RemoveAll(tran => tran.Identifier == transition.Identifier);
        }

        public bool HaveAnyEquals(IStateTransitionPending transition)
        {
            return Find(tran => tran == transition || tran.Identifier == transition.Identifier) != null;
        }

        public int Count
        {
            get { return MyPendencies.Count(); }
        }
    }
}
