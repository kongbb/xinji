using System.Text;
using EasyNetQ;

namespace CG.Access.MessageBus.Components
{
    public class MessageBusSerializer : ISerializer
    {
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        public byte[] MessageToBytes<T>(T message)
        {
            var bytes = Encoding.UTF8.GetBytes(
                JsonConvert.SerializeObject(message, _serializerSettings));
            return bytes;
        }

        public T BytesToMessage<T>(byte[] bytes)
        {
            var message = JsonConvert.DeserializeObject<T>(
                Encoding.UTF8.GetString(bytes), _serializerSettings);
            return message;
        }
    }
}