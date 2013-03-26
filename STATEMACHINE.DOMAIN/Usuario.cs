using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateMachine.Skeleton;

namespace StateMachine.Library.Entities
{
    public class Usuario
    {
        public Usuario(string nome)
        {
            this.Nome = nome;
        }

        public Usuario(IStateMachineProfile perfil, string nome)
        {
            this.Perfil = perfil;
            this.Nome = nome;
        }

        public string Nome { get; protected set; }

        public IStateMachineProfile Perfil { get; set; }
    }
}
