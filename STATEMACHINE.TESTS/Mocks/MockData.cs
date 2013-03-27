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
            var analise = new StateMachineState("Análise Crédito");

            var policy = new StateTransitionPolicy(new Cargo());

            var transicaoEmNegociacaoParaanalise = new StateTransition(emNegociacao, analise);
            transicaoEmNegociacaoParaanalise.Identifier = 1;
            transicaoEmNegociacaoParaanalise.Name = "De Em Negociação para Em Analise";
            transicaoEmNegociacaoParaanalise.Policy = policy;
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaanalise);

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

            var transicaoanaliseParaanalise = new StateTransition(analise, analise);
            transicaoanaliseParaanalise.Identifier = 6;
            transicaoanaliseParaanalise.Name = "De Em Analise para Em Analise";
            transicaoanaliseParaanalise.Policy = policy;
            analise.Transitions.Add(transicaoanaliseParaanalise);

            return new List<IStateMachineState> { emNegociacao, aprovado, desistencia, analise };
        }

        internal List<IStateMachineState> ConsultarEstadosSemAlcadaDaMaquinaDeEstado()
        {
            var emNegociacao = new StateMachineState("Em Negociação");
            var aprovado = new StateMachineState("Aprovado");
            var desistencia = new StateMachineState("Desistência");
            var analise = new StateMachineState("Em Análise");

            var transicaoEmNegociacaoParaanalise = new StateTransition(emNegociacao, analise);
            transicaoEmNegociacaoParaanalise.Identifier = 1;
            transicaoEmNegociacaoParaanalise.Name = "De Em Negociação para Em Analise";
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaanalise);

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

            var transicaoanaliseParaanalise = new StateTransition(analise, analise);
            transicaoanaliseParaanalise.Identifier = 6;
            transicaoanaliseParaanalise.Name = "De Em Analise para Em Analise";
            analise.Transitions.Add(transicaoanaliseParaanalise);

            return new List<IStateMachineState> { emNegociacao, aprovado, desistencia, analise };
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
            var analise = new StateMachineState("Em Análise",estadoInvalidoSpecification);

            var policy = new StateTransitionPolicy(new Cargo());

            var transicaoEmNegociacaoParaanalise = new StateTransition(emNegociacao, analise);
            transicaoEmNegociacaoParaanalise.Identifier = 1;
            transicaoEmNegociacaoParaanalise.Name = "De Em Negociação para Em Analise";
            transicaoEmNegociacaoParaanalise.Policy = policy;
            emNegociacao.Transitions.Add(transicaoEmNegociacaoParaanalise);

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

            var transicaoanaliseParaanalise = new StateTransition(analise, analise);
            transicaoanaliseParaanalise.Identifier = 6;
            transicaoanaliseParaanalise.Name = "De Em Analise para Em Analise";
            transicaoanaliseParaanalise.Policy = policy;
            analise.Transitions.Add(transicaoanaliseParaanalise);

            return new List<IStateMachineState> { emNegociacao, aprovado, desistencia, analise };
        }
    }
}
