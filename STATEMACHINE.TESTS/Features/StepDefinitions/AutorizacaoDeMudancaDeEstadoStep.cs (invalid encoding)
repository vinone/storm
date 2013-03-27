using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using STATEMACHINE.TESTS.Mocks;
using STATEMACHINE.DOMAIN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STATEMACHINE.SKELETON;
using Rhino.Mocks;

namespace STATEMACHINE.TESTS.Features.StepDefinitions
{
    [Binding]
    public class AutorizacaoDeMudancaDeEstadoStep
    {
        private string estadoInicial;
        private string estadoFinal;
        private IStateMachine _stateMachine;
        private Usuario _usuario;
        private MockData _mockData = new MockData();
        private MockRepository _mocks = new MockRepository();
        private IUsuarioRepositorio _usuarioRepositorio;
        private IStateMachineRepository _stateMachineRepository;
        private ICustomStateMachineControllerContext _contextoComAlcada;

        #region Cenario: Usuário com permissão

        [Given(@"um usuário com cargo ""Aprovador""")]
        public void DadoUmUsuarioComCargoAprovador()
        {
            ConfigurarRepositorioParaObterUmUsuarioAprovador();
            _usuario = _usuarioRepositorio.ObterUsuarioPeloCodigo("usuario.aprovador");
        }

        [Then(@"o estado da máquina deve estar alterado")]
        public void EntaoOEstadoDaMaquinaDeveEstarAlterado()
        {
            Assert.AreNotEqual(estadoInicial, estadoFinal);
        }

        #endregion

        #region Comum: Act

        [When(@"ele solicita a alteração de estado")]
        public void QuandoEleSolicitaAAlteracaoDeEstado()
        {
            ConfigurarRepositorioParaObterUmaMaquinaDeEstado();
            PrepararAçãoDoTeste();
        }

        #endregion

        #region Cenario: Usuário sem permissão

        [Given(@"um usuário com cargo ""Não Aprovador""")]
        public void DadoUmUsuarioComCargoNaoAprovador()
        {
            ConfigurarRepositorioParaObterUmUsuarioNaoAprovador();
            _usuario = _usuarioRepositorio.ObterUsuarioPeloCodigo("usuario.naoaprovador");
        }

        [Then(@"o estado da máquina deve ser igual ao inicial")]
        public void EntaoOEstadoDaMaquinaDeveSerIgualAoInicial()
        {
            Assert.AreEqual(estadoInicial, estadoFinal);
        }

        #endregion

        #region Cenario: Transição sem alçada

        [Given(@"uma transição de estado sem alçada")]
        public void DadoUmaTransicaoDeEstadoSemAlcada()
        {
            ConfigurarRepositorioParaObterUmUsuarioAprovador();
            _usuario = _usuarioRepositorio.ObterUsuarioPeloCodigo("usuario.aprovador");
        }

        [When(@"o usuário solicita a alteração de estado")]
        public void QuandoOUsuarioSolicitaAAlteracaoDeEstado()
        {
            ConfigurarRepositorioParaObterUmaMaquinaDeEstadoSemAlcadaNasTransicoes();
            PrepararAçãoDoTeste();
        }

        #endregion

        private void ConfigurarRepositorioParaObterUmUsuarioAprovador()
        {
            _usuarioRepositorio = null;
            var usuario = _mockData.ObterUsuarioAprovador();
            _usuarioRepositorio = _mocks.StrictMock<IUsuarioRepositorio>();
            Expect.Call(_usuarioRepositorio.ObterUsuarioPeloCodigo("usuario.aprovador"))
                .Return(usuario);
            _mocks.Replay(_usuarioRepositorio);
        }

        private void ConfigurarRepositorioParaObterUmUsuarioNaoAprovador()
        {
            _usuarioRepositorio = null;
            var usuario = _mockData.ObterUsuarioNaoAprovador();
            _usuarioRepositorio = _mocks.StrictMock<IUsuarioRepositorio>();
            Expect.Call(_usuarioRepositorio.ObterUsuarioPeloCodigo("usuario.naoaprovador"))
                .Return(usuario);
            _mocks.Replay(_usuarioRepositorio);
        }

        private void ConfigurarRepositorioParaObterUmaMaquinaDeEstado()
        {
            var maquinaDeEstado = _mockData.ObterMaquinaDeEstado();

            _stateMachineRepository = _mocks.StrictMock<IStateMachineRepository>();
            Expect.Call(_stateMachineRepository.GetStateMachineByIdentifier(1))
                .Return(maquinaDeEstado);
            _mocks.Replay(_stateMachineRepository);
        }

        private void ConfigurarRepositorioParaObterUmaMaquinaDeEstadoSemAlcadaNasTransicoes()
        {
            var maquinaDeEstado = _mockData.ObterMaquinaDeEstadoSemAlcadaDeTransicao();

            _stateMachineRepository = _mocks.StrictMock<IStateMachineRepository>();
            Expect.Call(_stateMachineRepository.GetStateMachineByIdentifier(1))
                .Return(maquinaDeEstado);
            _mocks.Replay(_stateMachineRepository);
        }

        private void PrepararAçãoDoTeste()
        {
            _stateMachine = _stateMachineRepository.GetStateMachineByIdentifier(1);
            _stateMachine.Start();
            estadoInicial = _stateMachine.CurrentState.Name;
            var transition = _stateMachine.States.First().Transitions.First();

            _contextoComAlcada = new TransitionPolicyControllerContext(_stateMachine,transition,_usuario.Cargo);
            _contextoComAlcada.Release();
            estadoFinal = _stateMachine.CurrentState.Name;
        }
    }
}
