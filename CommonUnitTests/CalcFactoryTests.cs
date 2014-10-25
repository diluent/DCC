using Common.Calculator;
using Common.Calculator.CalcImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonUnitTests
{
    [TestClass]
    public class CalcFactoryTests
    {
        [TestMethod]
        public void CalcFactoryTest()
        {
            Assert.AreEqual((new CalcFactory()).Get(CalculationType.AVG_ROW).GetType(), typeof(AvgRow));
            Assert.AreEqual((new CalcFactory()).Get(CalculationType.DEV_ROW).GetType(), typeof(DevRow));
            Assert.AreEqual((new CalcFactory()).Get(CalculationType.DIFF).GetType(), typeof(Diff));
            Assert.AreEqual((new CalcFactory()).Get(CalculationType.DIFF_LOG).GetType(), typeof(DiffLog));
            Assert.AreEqual((new CalcFactory()).Get(CalculationType.DIV).GetType(), typeof(Div));
            Assert.AreEqual((new CalcFactory()).Get(CalculationType.MAX_ROW).GetType(), typeof(MaxRow));
            Assert.AreEqual((new CalcFactory()).Get(CalculationType.MIN_ROW).GetType(), typeof(MinRow));
            Assert.AreEqual((new CalcFactory()).Get(CalculationType.MULT).GetType(), typeof(Mult));
            Assert.AreEqual((new CalcFactory()).Get(CalculationType.SUM).GetType(), typeof(Sum));
        }
    }
}
