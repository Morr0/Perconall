using AutoMapper;
using Perconall.Core.Dtos;
using Perconall.Core.Models;

namespace Perconall.Core.Utilities.MappingProfiles
{
    public class EntryModelDtosMappingsProfile : Profile
    {
        public EntryModelDtosMappingsProfile()
        {
            CreateMap<AddEntryDto, Entry>();
        }
    }
}