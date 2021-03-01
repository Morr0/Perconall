using AutoMapper;
using Perconall.Dtos;
using Perconall.Models;

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