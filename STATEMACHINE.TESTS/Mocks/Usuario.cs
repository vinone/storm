using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STATEMACHINE.SKELETON;

namespace STATEMACHINE.TESTS.Mocks
{
    public class Usuario : ICredentialProvider
    {
        public Usuario(string nome)
        {
            this.Nome = nome;
        }

        public string Nome { get; protected set; }

        public ICredential Cargo { get; set; }

        public ICredential ProvideCredential()
        {
            return this.Cargo;
        }
    }
}
