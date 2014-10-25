using System;
using System.Linq;

namespace Common.Calculator.CalcImpl
{
    public class Diff : ICalc
    {
        public double GetResult(double[] data)
        {
            if (data == null || !data.Any())
                throw new Exception("data are null or empty");

            var sum = data[0];
            for (var i = 1; i < data.Count(); i++)
            {
                sum -= data[i];
            }
            return sum;
        }
    }
}
