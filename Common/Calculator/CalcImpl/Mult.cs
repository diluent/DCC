using System;
using System.Linq;

namespace Common.Calculator.CalcImpl
{
    public class Mult : ICalc
    {
        public double GetResult(double[] data)
        {
            if (data == null || !data.Any())
                throw new Exception("data are null or empty");

            var res = 1d;
            for (var i = 0; i < data.Count(); i++)
            {
                res *= data[0];
            }
            return res;
        }
    }
}
