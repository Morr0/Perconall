using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Perconall.Core.Constants;
using Perconall.Core.Utilities.Configuration;
using RabbitMQ.Client;

namespace Perconall.Services.MessageQueueingService
{
    // WILL INIT SYNCHRONOUSLY
    public class MessageQueueService : IMessageQueueService, IDisposable
    {
        private IConnection _connection;
        private IModel _channel;

        public MessageQueueService(IOptions<ConnectionStrings> connectionStrings)
        {
            Init(connectionStrings.Value.RabbitMq);
        }

        private void Init(string connectionString)
        {
            var connectionFactory = new ConnectionFactory();
            _connection = connectionFactory.CreateConnection(connectionString);

            _channel = _connection.CreateModel();

            _channel.QueueDeclare(MessagingServiceConstants.QueueName, true, false, false, null);
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

        public async Task Publish<T>(T obj)
        {
            await Task.Run(() =>
            {
                string serializedJson = JsonSerializer.Serialize(obj);
                byte[] bytes = Encoding.UTF8.GetBytes(serializedJson);
                _channel.BasicPublish("", MessagingServiceConstants.QueueName, body: bytes);
            }).ConfigureAwait(false);
        }
    }
}