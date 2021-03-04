using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Perconall.Core.Constants;
using Perconall.Core.Dtos;
using Perconall.Core.Factories;
using Perconall.Core.Repositories;
using Perconall.Core.Utilities.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Perconall.Worker.BackgroundServices.EntriesService
{
    public class EntryService : IHostedService
    {
        private readonly EntryFactory _entryFactory;
        private Database _database;
        private readonly IServiceScope _serviceScope;
        private IConnection _connection;
        private IModel _channel;
        
        public EntryService(IOptions<ConnectionStrings> connectionStrings, EntryFactory entryFactory, IServiceScopeFactory serviceScopeFactory)
        {
            _entryFactory = entryFactory;

            _serviceScope = serviceScopeFactory.CreateScope();
            
            Init(connectionStrings.Value.RabbitMq);
        }

        private void Init(string connectionString)
        {
            var connectionFactory = new ConnectionFactory
            {
                // IMPORTANT set to true, otherwise AsyncEventingBasicConsumer won't receive events
                DispatchConsumersAsync = true
            };
            _connection = connectionFactory.CreateConnection(connectionString);
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(MessagingServiceConstants.QueueName, true, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += Handle;
            _channel.BasicConsume(MessagingServiceConstants.QueueName, true, consumer);
        }

        private async Task Handle(object obj, BasicDeliverEventArgs eventArgs)
        {
            string messageBody = Encoding.UTF8.GetString(eventArgs.Body.Span);
            var addEntryDto = JsonSerializer.Deserialize<AddEntryDto>(messageBody);
        
            await AddEntry(addEntryDto).ConfigureAwait(false);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _database = _serviceScope.ServiceProvider.GetService<Database>();
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Dispose();
            _connection.Dispose();
            _serviceScope.Dispose();

            return Task.CompletedTask;
        }

        private async Task AddEntry(AddEntryDto addEntryDto)
        {
            var entry = _entryFactory.Create(addEntryDto);

            await _database.EntryTable.AddAsync(entry).ConfigureAwait(false);
            await _database.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}