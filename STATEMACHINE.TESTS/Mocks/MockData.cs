using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STATEMACHINE.DOMAIN;
using STATEMACHINE.SKELETON;

namespace STATEMACHINE.TESTS.Mocks
{
    internal class MockData
    {
        internal Usuario ObterUsuarioAprovador()
        {
            return new Usuario("Usuario Aprovador")
            {
                Cargo = new Cargo()
            };
        }

        internal Usuario ObterUsuarioNaoAprovador()
        {
            return new Usuario("Usuario Não Aprovador")
            {
                Cargo = new CargoNaoAprovador()
            };
        }

        internal IStateMachine ObterMaquinaDeEstado()
        {
            var maquinaDeEstado = new StateMachine();
            var estados = this.ConsultarEstadosDaMaquinaDeEstado();

            foreach (var estado in estados)
                maquinaDeEstado.States.Add(estado);

            return maquinaDeEstado;
        }

        internal IStateMachine ObterNovaMaquinaDeEstado()
        {
            return new StateMachine();
        }

        internal List<IStateMachineState> ConsultarEstadosDaMaquinaDeEstado()
        {
            var emNegociacao = new StateMachineState("Em Negociação");
            var aprovado = new StateMachineState("Aprovado");
            var desistencia = new StateMachineState("Desistência");
            var analiseCredito = new StateMachineState("Análise Crédito");

            var policy = new StateTransitionPolicy(new Cargo());

            var transicaoEmNegociacaoParaAnaliseCredito = new StateTransition(emNegociacao, analiseCredito);
            transicaoEmNegociacaoParaAnaliseCredito.Identifier = 1;
            transicaoEmNegociacaoParaAnaliseCredito.Name = "De Em Negociação para Analise Credito";
            transicaoEmNegociacaoParaAnaliseCredito.Policy = policy;
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaAnaliseCredito);

            var transicaoEmNegociacaoParaAprovado = new StateTransition(emNegociacao, aprovado);
            transicaoEmNegociacaoParaAprovado.Identifier = 2;
            transicaoEmNegociacaoParaAprovado.Name = "De Em Negociacao para Aprovado";
            transicaoEmNegociacaoParaAprovado.Policy = policy;
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaAprovado);

            var transicaoEmNegociacaoParaDesistencia = new StateTransition(emNegociacao, desistencia);
            transicaoEmNegociacaoParaDesistencia.Identifier = 3;
            transicaoEmNegociacaoParaDesistencia.Name = "De Em Negociacao para Desistencia";
            transicaoEmNegociacaoParaDesistencia.Policy = policy;
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaDesistencia);

            var transicaoDesistenciaParaEmNegociacao = new StateTransition(desistencia, emNegociacao);
            transicaoDesistenciaParaEmNegociacao.Identifier = 4;
            transicaoDesistenciaParaEmNegociacao.Name = "De Desistencia para Em Negociacao";
            transicaoDesistenciaParaEmNegociacao.Policy = policy;
            desistencia.Transitions.Add(transicaoDesistenciaParaEmNegociacao);

            var transicaoAprovadoParaAprovado = new StateTransition(aprovado, aprovado);
            transicaoAprovadoParaAprovado.Identifier = 5;
            transicaoAprovadoParaAprovado.Name = "De Aprovado para Aprovado";
            transicaoAprovadoParaAprovado.Policy = policy;
            aprovado.Transitions.Add(transicaoAprovadoParaAprovado);

            var transicaoAnaliseCreditoParaAnaliseCredito = new StateTransition(analiseCredito, analiseCredito);
            transicaoAnaliseCreditoParaAnaliseCredito.Identifier = 6;
            transicaoAnaliseCreditoParaAnaliseCredito.Name = "De Analise Credito para Analise Credito";
            transicaoAnaliseCreditoParaAnaliseCredito.Policy = policy;
            analiseCredito.Transitions.Add(transicaoAnaliseCreditoParaAnaliseCredito);

            return new List<IStateMachineState> { emNegociacao, aprovado, desistencia, analiseCredito };
        }

        internal List<IStateMachineState> ConsultarEstadosSemAlcadaDaMaquinaDeEstado()
        {
            var emNegociacao = new StateMachineState("Em Negociação");
            var aprovado = new StateMachineState("Aprovado");
            var desistencia = new StateMachineState("Desistência");
            var analiseCredito = new StateMachineState("Análise Crédito");

            var transicaoEmNegociacaoParaAnaliseCredito = new StateTransition(emNegociacao, analiseCredito);
            transicaoEmNegociacaoParaAnaliseCredito.Identifier = 1;
            transicaoEmNegociacaoParaAnaliseCredito.Name = "De Em Negociação para Analise Credito";
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaAnaliseCredito);

            var transicaoEmNegociacaoParaAprovado = new StateTransition(emNegociacao, aprovado);
            transicaoEmNegociacaoParaAprovado.Identifier = 2;
            transicaoEmNegociacaoParaAprovado.Name = "De Em Negociacao para Aprovado";
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaAprovado);

            var transicaoEmNegociacaoParaDesistencia = new StateTransition(emNegociacao, desistencia);
            transicaoEmNegociacaoParaDesistencia.Identifier = 3;
            transicaoEmNegociacaoParaDesistencia.Name = "De Em Negociacao para Desistencia";
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaDesistencia);

            var transicaoDesistenciaParaEmNegociacao = new StateTransition(desistencia, emNegociacao);
            transicaoDesistenciaParaEmNegociacao.Identifier = 4;
            transicaoDesistenciaParaEmNegociacao.Name = "De Desistencia para Em Negociacao";
            desistencia.Transitions.Add(transicaoDesistenciaParaEmNegociacao);

            var transicaoAprovadoParaAprovado = new StateTransition(aprovado, aprovado);
            transicaoAprovadoParaAprovado.Identifier = 5;
            transicaoAprovadoParaAprovado.Name = "De Aprovado para Aprovado";
            aprovado.Transitions.Add(transicaoAprovadoParaAprovado);

            var transicaoAnaliseCreditoParaAnaliseCredito = new StateTransition(analiseCredito, analiseCredito);
            transicaoAnaliseCreditoParaAnaliseCredito.Identifier = 6;
            transicaoAnaliseCreditoParaAnaliseCredito.Name = "De Analise Credito para Analise Credito";
            analiseCredito.Transitions.Add(transicaoAnaliseCreditoParaAnaliseCredito);

            return new List<IStateMachineState> { emNegociacao, aprovado, desistencia, analiseCredito };
        }

        internal IStateMachine ObterMaquinaDeEstadoSemAlcadaDeTransicao()
        {
            var maquinaDeEstado = new StateMachine();
            var estados = this.ConsultarEstadosSemAlcadaDaMaquinaDeEstado();

            foreach (var estado in estados)
                maquinaDeEstado.States.Add(estado);

            return maquinaDeEstado;
        }

        internal List<IStateTransition> ConsultarTransicoesPendentes()
        {
            return new List<IStateTransition>
            {
                ConsultarEstadosDaMaquinaDeEstado()
                    .First(x => x.Name == "Em Negociação")
                    .Transitions
                    .First()
            };
        }

        internal List<IStateMachineState> ConsultarEstadosInvalidos()
        {
            var estadoInvalidoSpecification = new EstadoInvalidoSpecification();
            var emNegociacao = new StateMachineState("Em Negociação",estadoInvalidoSpecification);
            var aprovado = new StateMachineState("Aprovado",estadoInvalidoSpecification);
            var desistencia = new StateMachineState("Desistência",estadoInvalidoSpecification);
            var analiseCredito = new StateMachineState("Análise Crédito",estadoInvalidoSpecification);

            var policy = new StateTransitionPolicy(new Cargo());

            var transicaoEmNegociacaoParaAnaliseCredito = new StateTransition(emNegociacao, analiseCredito);
            transicaoEmNegociacaoParaAnaliseCredito.Identifier = 1;
            transicaoEmNegociacaoParaAnaliseCredito.Name = "De Em Negociação para Analise Credito";
            transicaoEmNegociacaoParaAnaliseCredito.Policy = policy;
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaAnaliseCredito);

            var transicaoEmNegociacaoParaAprovado = new StateTransition(emNegociacao, aprovado);
            transicaoEmNegociacaoParaAprovado.Identifier = 2;
            transicaoEmNegociacaoParaAprovado.Name = "De Em Negociacao para Aprovado";
            transicaoEmNegociacaoParaAprovado.Policy = policy;
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaAprovado);

            var transicaoEmNegociacaoParaDesistencia = new StateTransition(emNegociacao, desistencia);
            transicaoEmNegociacaoParaDesistencia.Identifier = 3;
            transicaoEmNegociacaoParaDesistencia.Name = "De Em Negociacao para Desistencia";
            transicaoEmNegociacaoParaDesistencia.Policy = policy;
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaDesistencia);

            var transicaoDesistenciaParaEmNegociacao = new StateTransition(desistencia, emNegociacao);
            transicaoDesistenciaParaEmNegociacao.Identifier = 4;
            transicaoDesistenciaParaEmNegociacao.Name = "De Desistencia para Em Negociacao";
            transicaoDesistenciaParaEmNegociacao.Policy = policy;
            desistencia.Transitions.Add(transicaoDesistenciaParaEmNegociacao);

            var transicaoAprovadoParaAprovado = new StateTransition(aprovado, aprovado);
            transicaoAprovadoParaAprovado.Identifier = 5;
            transicaoAprovadoParaAprovado.Name = "De Aprovado para Aprovado";
            transicaoAprovadoParaAprovado.Policy = policy;
            aprovado.Transitions.Add(transicaoAprovadoParaAprovado);

            var transicaoAnaliseCreditoParaAnaliseCredito = new StateTransition(analiseCredito, analiseCredito);
            transicaoAnaliseCreditoParaAnaliseCredito.Identifier = 6;
            transicaoAnaliseCreditoParaAnaliseCredito.Name = "De Analise Credito para Analise Credito";
            transicaoAnaliseCreditoParaAnaliseCredito.Policy = policy;
            analiseCredito.Transitions.Add(transicaoAnaliseCreditoParaAnaliseCredito);

            return new List<IStateMachineState> { emNegociacao, aprovado, desistencia, analiseCredito };
        }
    }
}
