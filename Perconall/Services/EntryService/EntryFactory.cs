using System;
using AutoMapper;
using Perconall.Core.Models;
using Perconall.Dtos;

namespace Perconall.Services.EntryService
{
    public class EntryFactory
    {
        private readonly IMapper _mapper;

        public EntryFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public Entry Create(AddEntryDto addEntryDto)
        {
            var entry = new Entry();

            entry.Id = CreateId();
            entry.Date = DateTime.UtcNow.ToString("s");

            _mapper.Map(addEntryDto, entry);

            return entry;
        }

        private static string CreateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}