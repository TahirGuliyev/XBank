using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using XBank.EventBus.Abstractions;
using XBank.Shared.Abstractions;

namespace XBank.EventBus.RabbitMQ
{
    public class RabbitMQEventBus : IEventBus
    {
        private readonly IModel _channel;

        public RabbitMQEventBus(IConnection connection)
        {
            _channel = connection.CreateModel();
        }

        public void Publish(IEvent @event)
        {
            var queueName = @event.GetType().Name;

            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(exchange: "", routingKey: queueName, body: body);
        }
    }
}
