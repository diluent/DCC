using System;
using System.Linq;

namespace Common.Calculator.CalcImpl
{
    public class Sum : ICalc
    {
        public double GetResult(double[] data)
        {
            if (data == null)
                throw new Exception("data are null");

            var sum = 0d;
            for (var i = 0; i < data.Count(); i++)
            {
                sum += data[i];
            }
            return sum;
        }
    }
}
