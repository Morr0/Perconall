using AutoMapper;
using Perconall.Core.Models;
using Perconall.Dtos;

namespace Perconall.Services.EntryService
{
    public class EntryMappingProfile : Profile
    {
        public EntryMappingProfile()
        {
            CreateMap<AddEntryDto, Entry>();
        }
    }
}