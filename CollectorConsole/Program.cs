using Common;
using Common.Messenger;
using Common.Serializer;
using Common.Writer;

namespace CollectorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = Settings.Curr;

            var writer = new LogAndConsoleWriter(settings.DecisionsQueueName, settings.LogPath);
            var messenger = new MessengerWriterService(writer, new Serializer(), settings.DecisionsQueueName, settings.MqBrokerAddress);
            var logger = new LogWriter("CollectorExceptions", settings.LogPath);
            var collector = new Collector(messenger, logger);
            collector.Run();
        }
    }
}
