using System.IO;
using System.Linq;

namespace Common.Serializer
{
    public interface ISerializer
    {
        byte[] Serialize(object data);
        T Deserialize<T>(byte[] data);
    }

    /// <summary>
    /// Класс для работы с сериализацией Protobuf
    /// </summary>
    public class Serializer : ISerializer
    {
        
            /// <summary>
            /// Бинарная сериализация объекта
            /// </summary>
            /// <param name="data">сериализуемый объект</param>
            /// <returns>результат сериализации в строке</returns>
            public byte[] Serialize(object data)
            {
                if (data == null)
                    return null;
                using (var ms = new MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize(ms, data);
                    return ms.ToArray();
                }
            }

            /// <summary>
            /// Бинарная десериализация объекта
            /// </summary>
            /// <param name="data">строка из которой востанавломивем объект</param>
            /// <returns>востановленнвый объект</returns>
            public T Deserialize<T>(byte[] data)
            {
                if (data == null || !data.Any())
                    return default(T);
                using (var ms = new MemoryStream(data))
                {
                    ms.Position = 0;
                    var obj = ProtoBuf.Serializer.Deserialize<T>(ms);
                    ms.Close();
                    return obj;
                }
            }
    }
}
