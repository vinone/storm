using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using STATEMACHINE.SKELETON;
using STATEMACHINE.DOMAIN;
using STATEMACHINE.TESTS.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace STATEMACHINE.TESTS.Features.StepDefinitions
{
    [Binding]
    public class ValidaçãoDaAlteraçãoDeEstadoStep
    {
        private IStateMachine _stateMachine;
        private ICustomStateMachineControllerContext _customController;
        private Usuario _usuario;
        private IStateTransition _currentTransition;
        private IStateMachineState _initialState;
        private IStateMachineState _finalState;
        private MockData _mockData = new MockData();
        private MockRepository _mocks = new MockRepository();
        private IStateMachineRepository _stateMachineRepository;
        private IUsuarioRepositorio _usuarioRepositorio;

        #region Cenario: Estado válido

        [Given(@"uma máquina de estado")]
        public void DadoUmaMaquinaDeEstado()
        {
            ConfigurarRepositorioDaStateMachine();
            _stateMachine = _stateMachineRepository.GetStateMachineByIdentifier(1);
        }

        [Given(@"os seus estados válidos")]
        public void DadoOsSeusEstadosValidos()
        {
            ConfigurarRepositorioDosEstados("validos");
            CarregarEstadosNaMaquina();
        }

        [When(@"um usuário inicia a máquina de estado")]
        public void QuandoUmUsuarioIniciaAMaquinaDeEstado()
        {
            _stateMachine.Start();
            _initialState = _stateMachine.CurrentState;
            _currentTransition = _initialState.Transitions.First();

            ConfigurarRepositorioDoUsuario();
            _usuario = _usuarioRepositorio.ObterUsuarioPeloCodigo("usuario.aprovador");

            _customController = new TransitionPolicyControllerContext(_stateMachine, _currentTransition, _usuario.Cargo);
        }

        [When(@"o estado destino deve validar a alteração")]
        public void EntaoOEstadoDeDestinoDeveValidarAAlteração()
        {
            _currentTransition.Target.Specification.IsValidForMoveForward();
        }

        [Then(@"o estado deve ser alterado")]
        public void EAMudancaDeEstadoDeveOcorrer()
        {
            SetEstadoFinal();

            Assert.AreNotEqual(_initialState.Name, _finalState.Name);
        }

        #endregion

        #region Quando um usuário inicia a máquina de estado

        [When(@"a transição de estado é solicitada")]
        public void QuandoATransicaoDeEstadoAcontece()
        {
            _customController.Release();
        }

        #endregion

        #region Cenario: Estado inválido

        [Given(@"os seus estados inválidos")]
        public void DadoOsSeusEstadosInvalidos()
        {
            ConfigurarRepositorioDosEstados("invalidos");
            CarregarEstadosNaMaquina();
        }

        [Then(@"o estado deve ser igual ao inicial")]
        public void EntaoOEstadoDeveSerIgualAoInicial()
        {
            SetEstadoFinal();

            Assert.AreEqual(_initialState.Name, _finalState.Name);
        }

        #endregion

        private void ConfigurarRepositorioDaStateMachine()
        {
            var maquina = _mockData.ObterNovaMaquinaDeEstado();
            _stateMachineRepository = _mocks.StrictMock<IStateMachineRepository>();
            Expect.Call(_stateMachineRepository.GetStateMachineByIdentifier(1))
                .Return(maquina);
            _mocks.Replay(_stateMachineRepository);
        }

        private void ConfigurarRepositorioDosEstados(string tipo)
        {
            List<IStateMachineState> estados;

            if (tipo == "validos")
                estados = _mockData.ConsultarEstadosDaMaquinaDeEstado();
            else
                estados = _mockData.ConsultarEstadosInvalidos();

                _stateMachineRepository = _mocks.StrictMock<IStateMachineRepository>();
            Expect.Call(_stateMachineRepository.GetAllStatesFromAStateMachine(_stateMachine))
                .Return(estados);
            _mocks.Replay(_stateMachineRepository);
        }

        private void ConfigurarRepositorioDoUsuario()
        {
            var usuario = _mockData.ObterUsuarioAprovador();
            _usuarioRepositorio = _mocks.StrictMock<IUsuarioRepositorio>();
            Expect.Call(_usuarioRepositorio.ObterUsuarioPeloCodigo("usuario.aprovador"))
                .Return(usuario);
            _mocks.Replay(_usuarioRepositorio);
        }

        private void CarregarEstadosNaMaquina()
        {
            var estados = _stateMachineRepository
                .GetAllStatesFromAStateMachine(_stateMachine);

            foreach (var estado in estados)
                _stateMachine.States.Add(estado);
        }

        private void SetEstadoFinal()
        {
            _finalState = _stateMachine.CurrentState;
        }
    }
}
