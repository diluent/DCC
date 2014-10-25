using System.Linq;
using Common.Calculator;
using DistributorConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistributorConsoleUnitTests
{
    [TestClass]
    public class DataGeneratorTests
    {
        [TestMethod]
        public void GetNewTest()
        {
            var generator = new DataGenerator(CalculationType.DIFF, 200);
            var res = generator.GetNew();
            Assert.IsNotNull(res);
            Assert.AreEqual(CalculationType.DIFF, res.CalcType);
            Assert.AreEqual(200, res.Data.Count());
        }
    }
}
