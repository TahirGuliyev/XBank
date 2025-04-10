using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using XBank.EventBus.Abstractions;
using XBank.EventBus.RabbitMQ;

namespace XBank.EventBus.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, string hostName)
        {
            var factory = new ConnectionFactory { HostName = hostName };
            var connection = factory.CreateConnection();

            services.AddSingleton<IConnection>(connection);
            services.AddSingleton<IEventBus, RabbitMQEventBus>();

            return services;
        }
    }
}
