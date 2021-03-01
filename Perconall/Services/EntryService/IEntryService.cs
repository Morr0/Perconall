using System.Collections.Generic;
using System.Threading.Tasks;
using Perconall.Core.Models;
using Perconall.Dtos;

namespace Perconall.Services.EntryService
{
    public interface IEntryService
    {
        Task Add(AddEntryDto addEntryDto);
        Task<IEnumerable<Entry>> Get();
    }
}