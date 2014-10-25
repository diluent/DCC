using System.Linq;
using Common.Calculator;
using Common.Messenger;
using Common.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonUnitTests
{
    [TestClass]
    public class SerializerTests
    {
        [TestMethod]
        public void SerializeDeserializeTest()
        {
            var serializer = new Serializer();
            var data = new DataModel
            {
                CalcType = CalculationType.AVG_ROW,
                Data = new[] {10.1, 20.1}
            };
            var serData = serializer.Serialize(data);

            var desData = serializer.Deserialize<DataModel>(serData);

            Assert.AreEqual(data.CalcType, desData.CalcType);
            Assert.AreEqual(data.Data.Count(), desData.Data.Count());

            for (var i = 0; i < data.Data.Count(); i++)
            {
                Assert.AreEqual(data.Data[i], desData.Data[i]);                
            }
        }
    }
}
