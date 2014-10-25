using System;
using System.Threading;
using Common.Calculator;
using Common.Messenger;
using Common.Writer;

namespace CalculatorConsole
{
    /// <summary>
    /// Решатель
    /// </summary>
    public class Calculator
    {
        private readonly IMessengerService _taskMessenger;
        private readonly IMessengerService _decisionMessenger;
        private readonly ICalcFactory _calcFactory;
        private readonly IWriter _logWriter;

        private bool _isRunning = true;

        public Calculator(IMessengerService taskMessenger, IMessengerService decisionMessenger, ICalcFactory calcFactory, IWriter logWriter)
        {
            _taskMessenger = taskMessenger;
            _decisionMessenger = decisionMessenger;
            _calcFactory = calcFactory;
            _logWriter = logWriter;
        }

        public void Run()
        {
            while (_isRunning)
            {
                try
                {
                    var data = _taskMessenger.Get<DataModel>();
                    if (data == null)
                    {
                        Interrupt();
                        continue;                        
                    }

                    var calc = _calcFactory.Get(data.CalcType);

                    var result = calc.GetResult(data.Data);
                    _decisionMessenger.Send(new DataModel
                    {
                        CalcType = data.CalcType,
                        Data = new[] {result}
                    });
                }
                catch (Exception e)
                {
                    _logWriter.Write(e.StackTrace);
                }
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }

        private static void Interrupt()
        {
            Thread.Sleep(100);
        }
    }
}
