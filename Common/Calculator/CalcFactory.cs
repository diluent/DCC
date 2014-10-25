using System;
using Common.Calculator.CalcImpl;

namespace Common.Calculator
{
    public interface ICalc
    {
        double GetResult(double[] data);
    }

    public interface ICalcFactory
    {
        ICalc Get(CalculationType type);
    }

    public class CalcFactory : ICalcFactory
    {

        private ICalc _currentCalcImpl;

        private T Get<T>() where T : ICalc, new()
        {
            if(_currentCalcImpl == null || _currentCalcImpl.GetType() != typeof(T))
                return (T)(_currentCalcImpl = new T());
            return (T)_currentCalcImpl;
        }

        public ICalc Get(CalculationType type)
        {
            switch (type)
            {
                case CalculationType.SUM:
                    return Get<Sum>();
                case CalculationType.DIFF:
                    return Get<Diff>();
                case CalculationType.DIFF_LOG:
                    return Get<DiffLog>();
                case CalculationType.MULT:
                    return Get<Mult>();
                case CalculationType.DIV:
                    return Get<Div>();
                case CalculationType.AVG_ROW:
                    return Get<AvgRow>();
                case CalculationType.DEV_ROW:
                    return Get<DevRow>();
                case CalculationType.MAX_ROW:
                    return Get<MaxRow>();
                case CalculationType.MIN_ROW:
                    return Get<MinRow>();
                default:
                    throw new Exception("There isn't implementation for calctype " + type);
            } 
        }
    }
}
