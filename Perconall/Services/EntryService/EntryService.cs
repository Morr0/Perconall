using System.Collections.Generic;
using System.Threading.Tasks;
using Perconall.Dtos;
using Perconall.Models;

namespace Perconall.Services.EntryService
{
    public class EntryService : IEntryService
    {
        private readonly EntryFactory _factory;
        private IList<Entry> _entries;

        public EntryService(EntryFactory factory)
        {
            _factory = factory;
            _entries = new List<Entry>();
        }
        
        public async Task Add(AddEntryDto addEntryDto)
        {
            var entry = _factory.Create(addEntryDto);
            _entries.Add(entry);
        }

        public async Task<IEnumerable<Entry>> Get()
        {
            return _entries;
        }
    }
}