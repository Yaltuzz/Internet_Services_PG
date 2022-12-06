using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Internet_Services_PG.Models;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.IO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Internet_Services_PG.Services
{
    public class HumidityConsumerService : BackgroundService
    {
        private readonly HumidityService _service;
        private readonly IModel _channel;

        public HumidityConsumerService(HumidityService service)
        {
            _service = service;
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
            _channel.QueueDeclare(queue: "humidity",
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
                Console.WriteLine("Received humidity {0}", message);
                var newObject = JsonSerializer.Deserialize<Humidity>(message);
                _service.Create(newObject);
            };
            _channel.BasicConsume(queue: "humidity",
                autoAck: true,
                consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
