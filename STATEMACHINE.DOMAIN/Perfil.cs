using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateMachine.Skeleton;

namespace StateMachine.Library.Entities
{
    public class Perfil : IStateMachineProfile
    {
        public Perfil(string name)
        {
            this.Name = name;
        }

        public string Identifier 
        {
            get { return Guid.NewGuid().ToString(); }
            set{}
        }

        public string Name { get; protected set; }

        private IList<IStateMachineState> _authorizedStates;

        public IList<IStateMachineState> AuthorizedStates
        {
            get
            {
                if (_authorizedStates == null)
                    _authorizedStates = new List<IStateMachineState>();

                return _authorizedStates;
            }
            set { _authorizedStates = value; }
        }
    }
}
