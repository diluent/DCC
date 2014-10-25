using System;
using System.Threading;
using Common.Calculator;
using Common.Messenger;
using Common.Writer;

namespace CollectorConsole
{
    /// <summary>
    /// Сборщик решений
    /// </summary>
    public class Collector
    {
        private readonly IMessengerService _decisionMessenger;
        private readonly IWriter _logWriter;

        private bool _isRunning = true;

        public Collector(IMessengerService decisionMessenger, IWriter logWriter)
        {
            _decisionMessenger = decisionMessenger;
            _logWriter = logWriter;
        }

        public void Run()
        {
            while (_isRunning)
            {
                try
                {
                    if (_decisionMessenger.Get<DataModel>() == null)
                        Interrupt();
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
            Thread.Sleep(1000);
        }
    }
}
