using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace STATEMACHINE.TESTS.Mocks
{
    public interface IUsuarioRepositorio
    {
        Usuario ObterUsuarioPeloCodigo(string codigo);
    }
}
