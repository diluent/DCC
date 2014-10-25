using System;
using System.Linq;

namespace Common.Calculator.CalcImpl
{
    public class Div : ICalc
    {
        public double GetResult(double[] data)
        {
            if (data == null || !data.Any())
                throw new Exception("data are null or empty");

            var res = data[0];
            for (var i = 1; i < data.Count(); i++)
            {
                res /= data[0];
            }
            return res;
        }
    }
}
