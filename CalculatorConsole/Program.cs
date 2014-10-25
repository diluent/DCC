using Common;
using Common.Calculator;
using Common.Messenger;
using Common.Serializer;
using Common.Writer;

namespace CalculatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = Settings.Curr;

            var calcFactory = new CalcFactory();
            var taskMessanger = new MessengerService(new Serializer(), settings.TasksQueueName, settings.MqBrokerAddress);
            var decisionMessanger = new MessengerWriterService(new ConsoleWriter(), new Serializer(), settings.DecisionsQueueName, settings.MqBrokerAddress);
            var logger = new LogWriter("CalculatorExceptions", settings.LogPath);
            var calc = new Calculator(taskMessanger, decisionMessanger, calcFactory, logger);
            calc.Run();
        }
    }
}
