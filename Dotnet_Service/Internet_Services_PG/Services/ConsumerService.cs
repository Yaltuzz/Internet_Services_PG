using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Internet_Services_PG.Models;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Internet_Services_PG.Services
{
    public class ConsumerService : BackgroundService
    {
        private readonly PressureService _pressureService;

        public ConsumerService(PressureService pressureService)
        {
            _pressureService = pressureService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "si_176446_rabbit" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "first",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received xdd {0}", message);
            };
            channel.BasicConsume(queue: "first",
                autoAck: true,
                consumer: consumer);
        }
    }
}
