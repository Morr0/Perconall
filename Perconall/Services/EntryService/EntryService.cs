using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Perconall.Core.Models;
using Perconall.Core.Repositories;
using Perconall.Dtos;

namespace Perconall.Services.EntryService
{
    public class EntryService : IEntryService
    {
        private readonly EntryFactory _factory;
        private readonly Database _database;

        public EntryService(EntryFactory factory, Database database)
        {
            _factory = factory;
            _database = database;
        }
        
        public async Task Add(AddEntryDto addEntryDto)
        {
            var entry = _factory.Create(addEntryDto);

            await _database.EntryTable.AddAsync(entry).ConfigureAwait(false);
            await _database.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entry>> Get()
        {
            return _database.EntryTable.AsNoTracking();
        }
    }
}