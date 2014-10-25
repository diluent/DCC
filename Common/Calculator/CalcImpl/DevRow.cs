using System;
using System.Linq;

namespace Common.Calculator.CalcImpl
{
    /// <summary>
    /// Стандартное отклонение ряда
    /// </summary>
    public class DevRow : ICalc
    {
        public double GetResult(double[] data)
        {
            if (data == null || !data.Any())
                throw new Exception("data are null or empty");

            var avg = data.Average(x => x);
            var sum = 0d;
            for (var i = 0; i < data.Count(); i++)
            {
                sum += Math.Pow(data[i] - avg, 2);
            }
            return Math.Sqrt(sum);
        }
    }
}
