using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WORKFLOW.TESTS.Mocks;

namespace WORKFLOW.TESTS
{
    [TestClass]
    public class WorkflowCommandTest
    {
        [TestMethod]
        public void DadoUmComandoParaAvancarDeveAvancar()
        {
            var exampleController = new ExampleFlowController();
            var implementation = new FlowMoveForwardImplementation(new AnotherStateSpecification());
            var command = new FlowMonitoramentoCommand(implementation);
            exampleController.SetCommand(command);

            try
            {
                exampleController.ExecuteCommand();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("MoveForwardCommand", ex.Message);
            }
        }

        [TestMethod]
        public void DadoUmComandoParaRetrocederDeveRetroceder()
        {
            var exampleController = new ExampleFlowController();
            var implementation = new FlowMoveBackwardImplementation(new AStateSpecification());
            var command = new FlowMonitoramentoCommand(implementation);
            exampleController.SetCommand(command);

            try
            {
                exampleController.ExecuteCommand();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("MoveBackwardCommand", ex.Message);
            }


        }
    }

}
