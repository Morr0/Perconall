using System.Collections.Generic;
using System.Threading.Tasks;
using Perconall.Core.Dtos;
using Perconall.Core.Models;

namespace Perconall.Services.EntryService
{
    public interface IEntryService
    {
        Task Add(AddEntryDto addEntryDto);
        Task<IEnumerable<Entry>> Get();
    }
}