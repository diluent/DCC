using System.Text;
using ProtoBuf;

namespace Common.Calculator
{
    /// <summary>
    /// Модель данных заданий
    /// </summary>
    [ProtoContract]
    public class DataModel
    {
        [ProtoMember(1)]
        public CalculationType CalcType;
        [ProtoMember(2)]
        public double[] Data;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(CalcType).Append(", { ");
            sb.Append(string.Join(", ", Data));
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
