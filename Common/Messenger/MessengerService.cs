using Common.Serializer;
using RabbitMQ.Client;

namespace Common.Messenger
{
    public interface IMessengerService
    {
        /// <summary>
        /// Отправить в очередь
        /// </summary>
        /// <param name="data">модель данных</param>
        void Send<T>(T data);
        /// <summary>
        /// Получить из очереди
        /// </summary>
        /// <returns></returns>
        T Get<T>();
    }

    public class MessengerService : IMessengerService
    {

        private readonly string _queueName;
        private readonly ConnectionFactory _factory;
        private readonly ISerializer _serializer;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="serializer">реализация сериализатора</param>
        /// <param name="queueName">Имя очереди</param>
        /// <param name="uri">адрес брокера очередей</param>
        public MessengerService(ISerializer serializer, string queueName, string uri)
        {
            _serializer = serializer;
            _queueName = queueName;
            _factory = new ConnectionFactory { Uri = uri };
        }

        public void Send<T>(T data)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(_queueName, false, false, false, null);
                    channel.BasicPublish("", _queueName, null, _serializer.Serialize(data));
                }
            }
        }

        public T Get<T>()
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(_queueName, false, false, false, null);
                    var res = channel.BasicGet(_queueName, true);
                    return res == null || res.Body == null ?
                        default(T) : 
                        _serializer.Deserialize<T>(res.Body);
                }
            }
        }
    }
}
