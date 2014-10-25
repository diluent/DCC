using System;
using System.Linq;

namespace Common.Calculator.CalcImpl
{
    public class MinRow : ICalc
    {
        public double GetResult(double[] data)
        {
            if (data == null || !data.Any())
                throw new Exception("data are null or empty");
            return data.Min(x => x);
        }
    }
}
