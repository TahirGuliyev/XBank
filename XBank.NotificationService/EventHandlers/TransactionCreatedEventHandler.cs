using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using XBank.Shared.Events;

namespace XBank.NotificationService.EventHandlers
{
    public class TransactionCreatedEventHandler : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public TransactionCreatedEventHandler()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _channel.QueueDeclare(queue: nameof(TransactionCreatedEvent), durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);


                var @event = JsonConvert.DeserializeObject<TransactionCreatedEvent>(message);

                Console.WriteLine($"New transaction received!\n" +
                                  $" - CustomerId: {@event.CustomerId}\n" +
                                  $" - Type: {@event.Type}\n" +
                                  $" - Amount: {@event.Amount}");
            };

            _channel.BasicConsume(queue: nameof(TransactionCreatedEvent), autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
