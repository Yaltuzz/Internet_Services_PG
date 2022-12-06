using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Internet_Services_PG.Models;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Internet_Services_PG.Services
{
    public class ConsumerService : BackgroundService
    {
        private readonly PressureService _pressureService;
        private readonly IModel _channel;

        public ConsumerService(PressureService pressureService)
        {
            _pressureService = pressureService;
            var factory = new ConnectionFactory() { HostName = "si_176446_rabbit" };
            IConnection connection;
            while (true)
            {
                try
                {
                    Console.WriteLine("Try To connect");
                    connection = factory.CreateConnection();
                    Console.WriteLine("Connection Success");
                    break;
                }
                catch (BrokerUnreachableException exception)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Connection Fail");

                }
            }
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: "first",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };
            _channel.BasicConsume(queue: "first",
                autoAck: true,
                consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
