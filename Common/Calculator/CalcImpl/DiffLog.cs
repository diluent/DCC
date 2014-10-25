using System;
using System.Linq;

namespace Common.Calculator.CalcImpl
{
    public class DiffLog : ICalc
    {
        public double GetResult(double[] data)
        {
            if (data == null || !data.Any())
                throw new Exception("data are null or empty");

            var sum = Math.Log(data[0]);
            for (var i = 1; i < data.Count(); i++)
            {
                sum -= Math.Log(data[i]);
            }
            return sum;
        }
    }
}
