using System.Threading;
using Common.Calculator;
using Common.Messenger;
using Common.Writer;
using DistributorConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DistributorConsoleUnitTests
{
    [TestClass]
    public class DistributorTests
    {
        [TestMethod]
        public void DistributorRunTest()
        {
            var moq = new MockRepository(MockBehavior.Default);

            var logger = moq.Create<IWriter>();

            var m = moq.Create<IMessengerService>();
            var raised = false;
            m.Setup(r => r.Send(It.IsAny<DataModel>())).Callback(() => { raised = true; });

            var g = new DataGenerator(CalculationType.AVG_ROW, 150);

            var d = new Distributor(g, m.Object, logger.Object);

            var t = new Thread(d.Run);
            t.Start();
            Thread.Sleep(10);
            d.Stop();
            t.Join();
            Assert.IsTrue(raised);
        }
    }
}
