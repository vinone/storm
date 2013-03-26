using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using STATEMACHINE.TESTS.Mocks;
using Rhino.Mocks;
using STATEMACHINE.SKELETON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STATEMACHINE.DOMAIN;

namespace STATEMACHINE.TESTS.Features.StepDefinitions
{
    [Binding]
    public class AprovaçãoDeAlçadaStep
    {
        private IStateMachine _stateMachine;
        private Usuario _usuario;
        private MockData _mockData = new MockData();
        private MockRepository _mocks = new MockRepository();
        private IUsuarioRepositorio _usuarioRepositorio;
        private IStateMachineRepository _stateMachineRepository;
        private ICustomStateMachineControllerContext _contextoComAlcada;

        #region Cenario: Transição nova

        [Given(@"um usuário sem permissão altera o estado da máquina")]
        public void DadoUmUsuarioSemPermissaoAlteraOEstadoDaMaquina()
        {
            ConfigurarRepositorioParaObterUmUsuarioNaoAprovador();
            _usuario = _usuarioRepositorio.ObterUsuarioPeloCodigo("usuario.naoaprovador");
            ConfigurarRepositorioParaObterUmaMaquinaDeEstado();
            _stateMachine = _stateMachineRepository.GetStateMachineByIdentifier(1);
        }

        [When(@"a transição solicitar aprovação para a mudança")]
        public void QuandoATransicaoSolicitarAprovacaoParaAMudanca()
        {
            _stateMachine.Start();
            var transition = _stateMachine.CurrentState.Transitions.First();
            _contextoComAlcada = new TransitionPolicyControllerContext(_stateMachine,transition,_usuario.Cargo);
            _contextoComAlcada.Release();
        }

        [Then(@"deve ser criado uma pendência para o usuário aprovador")]
        public void EntaoDeveSerCriadoUmaPendenciaParaOUsuarioAprovador()
        {
            Assert.IsTrue(_stateMachine.TransitionsPending.Count > 0);
        }

        #endregion

        #region Cenario: Transição pendente

        [Given(@"um usuário com permissão de aprovação")]
        public void DadoUmUsuarioComPermissaoDeAprovacao()
        {
            ConfigurarRepositorioParaObterUmUsuarioAprovador();
            _usuario = _usuarioRepositorio.ObterUsuarioPeloCodigo("usuario.aprovador");

            ConfigurarRepositorioParaObterUmaMaquinaDeEstado();
            _stateMachine = _stateMachineRepository.GetStateMachineByIdentifier(1);
        }

        [When(@"o usuário inicia uma máquina de estado")]
        public void QuandoOUsuarioIniciaUmaMaquinaDeEstado()
        {
            _stateMachine.Start();
        }

        [Then(@"o usuário deve visualizar as transições pendentes de aprovação")]
        public void EntaoOUsuarioDeveVisualizarAsTransicoesPendentesDeAprovacao()
        {
            ConfigurarRepositorioParaConsultarTransicoesPendentes();

            var transicoesPendentes = _stateMachineRepository
                .GetAllPendencies(_stateMachine);

            foreach (var pendencia in transicoesPendentes)
                _stateMachine.TransitionsPending.PutNew(new StateTransitionPending(_stateMachine,pendencia));

            Assert.IsTrue(_stateMachine.TransitionsPending.MyPendencies.Count() > 0);
        }

        #endregion

        #region Cenario: Transição aprovada

        [When(@"o usuário aprova as transições pendentes")]
        public void QuandoOUsuarioAprovaAsTransicoesPendentes()
        {
            var transicoesParaAprovacao = _stateMachine.TransitionsPending.MyPendencies;
            var transicaoPendente = transicoesParaAprovacao.First();
            _contextoComAlcada = new TransitionPolicyControllerContext
                (_stateMachine, transicaoPendente.TransitionPending, _usuario.Cargo);
            _contextoComAlcada.Release();
        }

        [Then(@"não deve existir pendencias")]
        public void EntaoNaoDeveExistirPendencias()
        {
            Assert.IsTrue(_stateMachine.TransitionsPending.MyPendencies.Count() == 0);
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

        private void ConfigurarRepositorioParaConsultarTransicoesPendentes()
        {
            var transicoesPendentes = _mockData.ConsultarTransicoesPendentes();

            _stateMachineRepository = _mocks.StrictMock<IStateMachineRepository>();
            Expect.Call(_stateMachineRepository.GetAllPendencies(_stateMachine))
                .Return(transicoesPendentes);
            _mocks.Replay(_stateMachineRepository);
        }
    }
}
