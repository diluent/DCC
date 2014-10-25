using System;
using Common.Calculator;

namespace DistributorConsole
{
    public interface IDataGenerator
    {
        DataModel GetNew();
    }
    public class DataGenerator : IDataGenerator
    {
        private readonly Random _rand = new Random();
        private readonly int _countArray;
        private readonly CalculationType _calcType;

        public DataGenerator(CalculationType calcType, int countArray = 100)
        {
            _countArray = countArray;
            _calcType = calcType;
        }

        public DataModel GetNew()
        {
            var m = new DataModel
            {
                CalcType = _calcType,
                Data = new double[_countArray]
            };
            for (var i = 0; i < _countArray; i++)
                m.Data[i] = _rand.Next(100000) / 100d;
            return m;
        }
    }
}
