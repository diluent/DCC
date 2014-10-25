using Common.Calculator.CalcImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonUnitTests
{
    [TestClass]
    public class CalcImplTests
    {
        [TestMethod]
        public void AvgRowTest()
        {
            var calc = new AvgRow();
            var result = calc.GetResult(new[] {100.2, 200.2, 300.2});
            Assert.AreEqual(200.2, result, .01);
        }

        [TestMethod]
        public void DewRowTest()
        {
            var calc = new DevRow();
            var result = calc.GetResult(new[] { 34.4, 454.75, 342.56, 12.76 });
            Assert.AreEqual(383.67, result, .01);
        }

        [TestMethod]
        public void DiffTest()
        {
            var calc = new Diff();
            var result = calc.GetResult(new[] { 300.33, 300.33, 300.33 });
            Assert.AreEqual(-300.33, result, .01);
        }

        [TestMethod]
        public void DiffLogTest()
        {
            var calc = new DiffLog();
            var result = calc.GetResult(new[] { 34.4, 454.75, 342.56, 12.76 });
            Assert.AreEqual(-10.96, result, .01);
        }

        [TestMethod]
        public void DivTest()
        {
            var calc = new Div();
            var result = calc.GetResult(new[] { 34.4, 454.75, 342.56, 12.76 });
            Assert.AreEqual(1.73E-05, result, .01);
        }

        [TestMethod]
        public void MaxRowTest()
        {
            var calc = new MaxRow();
            var result = calc.GetResult(new[] { 34.4, 454.75, 342.56, 12.76 });
            Assert.AreEqual(454.75, result, .01);
        }

        [TestMethod]
        public void MinRowTest()
        {
            var calc = new MinRow();
            var result = calc.GetResult(new[] { 34.4, 454.75, 342.56, 12.76 });
            Assert.AreEqual(12.76, result, .01);
        }

        [TestMethod]
        public void MultTest()
        {
            var calc = new Mult();
            var result = calc.GetResult(new[] { 34.4, 454.75, 342.56, 12.76 });
            Assert.AreEqual(1400340.88, result, .01);
        }

        [TestMethod]
        public void SumTest()
        {
            var calc = new Sum();
            var result = calc.GetResult(new[] { 34.4, 454.75, 342.56, 12.76 });
            Assert.AreEqual(844.47, result, .01);
        }
    }
}
