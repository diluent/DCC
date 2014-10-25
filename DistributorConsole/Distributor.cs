using System;
using System.Threading;
using Common.Messenger;
using Common.Writer;

namespace DistributorConsole
{
    /// <summary>
    /// Раздаватель задач
    /// </summary>
    public class Distributor
    {
        private readonly IDataGenerator _dataGenerator;
        private readonly IMessengerService _taskMessenger;
        private readonly IWriter _logWriter;
        
        private bool _isRunning = true;

        public Distributor(IDataGenerator dataGenerator, IMessengerService taskMessenger, IWriter logWriter)
        {
            _dataGenerator = dataGenerator;
            _taskMessenger = taskMessenger;
            _logWriter = logWriter;
        }

        public void Run()
        {
            while (_isRunning)
            {
                try
                {
                    var data = _dataGenerator.GetNew();
                    _taskMessenger.Send(data);
                    Thread.Sleep(50);
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
    }
}
