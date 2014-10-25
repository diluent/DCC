using Common;
using Common.Calculator;
using Common.Messenger;
using Common.Serializer;
using Common.Writer;

namespace DistributorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const CalculationType calcType = CalculationType.DEV_ROW;
            var settings = Settings.Curr;

            var writer = new LogAndConsoleWriter(settings.TasksQueueName, settings.LogPath);
            var messenger = new MessengerWriterService(writer, new Serializer(), settings.TasksQueueName, settings.MqBrokerAddress);
            var generator = new DataGenerator(calcType);
            var logger = new LogWriter("DistributorExceptions", settings.LogPath);
            var distributor = new Distributor(generator, messenger, logger);
            distributor.Run();
        }
    }
}
