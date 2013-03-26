using WORKFLOW.TESTS.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WORKFLOW.DOMAIN;
using WORKFLOW.SKELETON;

namespace WORKFLOW.TESTS
{
    [TestClass]
    public class FlowsControllerTest
    {
        [TestMethod]
        public void DadoUmObjetoMutavelEUmFluxo_Avançar()
        {
            IMutable mutable = new AnObjectMutable();
            mutable.SetState(new AState());
            IFlow flow = new AnExampleFlow();
            IFlowsController flowsController = new FlowsController(mutable, flow);
            flowsController.MoveForward();
            IStep expectedStep = new AnotherState();
            var current = (AnObjectMutable)flowsController.GetCurrent();
            var currentStep = current.State;
            Assert.AreEqual(expectedStep.GetType(), currentStep.GetType());
        }

        [TestMethod]
        public void DadoUmObjetoMutavelEUmFluxo_Retroceder()
        {
            IMutable mutable = new AnObjectMutable();
            mutable.SetState(new AnotherState());
            IFlow flow = new AnExampleFlow();
            IFlowsController flowsController = new FlowsController(mutable, flow);
            flowsController.MoveBackward();
            IStep expectedStep = new AState();
            var current = (AnObjectMutable)flowsController.GetCurrent();
            var currentStep = current.State;
            Assert.AreEqual(expectedStep.GetType(), currentStep.GetType());
        }

        [TestMethod]
        public void DadoUmObjetoMutavelInvalidoEUmFluxo_NãoDeveAvançar()
        {
            var mutable = new AnInvalidObjectMutable();
            mutable.SetState(new AValidationState());
            IFlow flow = new AnotherExampleFlow();
            IFlowsController flowsController = new FlowsController(mutable, flow);
            flowsController.MoveForward();
            var expectedStep = new AValidationState();
            var current = (AnInvalidObjectMutable)flowsController.GetCurrent();
            var currentStep = current.State;
            Assert.AreEqual(currentStep.GetType(), expectedStep.GetType());
        }

        [TestMethod]
        public void DadoQueOFluxoEstaNoUltimoEstado_NãoDeveAvançar()
        {
            var mutable = new AnInvalidObjectMutable();
            mutable.SetState(new AValidationState());
            IFlow flow = new LastStateFlow();
            IFlowsController flowsController = new FlowsController(mutable, flow);
            flowsController.MoveForward();
            var expectedStep = new AValidationState();
            var current = (AnInvalidObjectMutable)flowsController.GetCurrent();
            var currentStep = current.State;
            Assert.AreEqual(currentStep.GetType(), expectedStep.GetType());
        }
    }
}
