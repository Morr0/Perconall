using System.Collections.Generic;
using System.Threading.Tasks;
using Perconall.Dtos;
using Perconall.Models;

namespace Perconall.Services.EntryService
{
    public interface IEntryService
    {
        Task Add(AddEntryDto addEntryDto);
        Task<IEnumerable<Entry>> Get();
    }
}