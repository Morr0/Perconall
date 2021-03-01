using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Perconall.Core.Models;
using Perconall.Core.Repositories;
using Perconall.Dtos;
using Perconall.Services.MessageQueueingService;

namespace Perconall.Services.EntryService
{
    public class EntryService : IEntryService
    {
        private readonly EntryFactory _factory;
        private readonly Database _database;
        private readonly IMessageQueueService _messageQueueService;

        public EntryService(EntryFactory factory, Database database, IMessageQueueService messageQueueService)
        {
            _factory = factory;
            _database = database;
            _messageQueueService = messageQueueService;
        }
        
        public async Task Add(AddEntryDto addEntryDto)
        {
            await _messageQueueService.Publish(addEntryDto).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Entry>> Get()
        {
            return _database.EntryTable.AsNoTracking();
        }
    }
}