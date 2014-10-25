using System.Configuration;

namespace Common
{
    /// <summary>
    /// Настройки приложения
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Имя очереди задач
        /// </summary>
        public string TasksQueueName { get; private set; }
        /// <summary>
        /// Имя очереди решений
        /// </summary>
        public string DecisionsQueueName { get; private set; }
        /// <summary>
        /// Путь для логов
        /// </summary>
        public string LogPath { get; private set; }
        /// <summary>
        /// Адрес брокера сообщений
        /// </summary>
        public string MqBrokerAddress { get; private set; }

        /// <summary>
        /// Экземпляр настроек
        /// </summary>
        public static Settings Curr
        {
            get
            {
                return new Settings
                {
                    TasksQueueName = ConfigurationManager.AppSettings["TasksQueueName"],
                    DecisionsQueueName = ConfigurationManager.AppSettings["DecisionsQueueName"],
                    LogPath = ConfigurationManager.AppSettings["LogPath"],
                    MqBrokerAddress = ConfigurationManager.AppSettings["MQBrokerAddress"]
                };
            }
        }
    }
}
