using Common.Serializer;
using Common.Writer;

namespace Common.Messenger
{
    /// <summary>
    /// Декоратор для записи в лог того, что отправляется в очередь или берется из нее
    /// </summary>
    public class MessengerWriterService : MessengerService, IMessengerService
    {
        private readonly IWriter _writer;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="writer">Писатель</param>
        /// <param name="serializer">Сериализатор</param>
        /// <param name="queueName">Имя очереди</param>
        /// <param name="address">Адрес брокера очередей</param>
        public MessengerWriterService(IWriter writer, ISerializer serializer, string queueName, string address)
            : base(serializer, queueName, address)
        {
            _writer = writer;
        }

        public new void Send<T>(T data)
        {
            base.Send(data);
            if(data != null)
                _writer.Write(data.ToString());
        }

        public new T Get<T>()
        {
            var data = base.Get<T>();
            if(data != null)
                _writer.Write(data.ToString());
            return data;
        }
    }
}
