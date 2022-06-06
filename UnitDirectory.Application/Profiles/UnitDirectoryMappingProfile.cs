using AutoMapper;
using UnitDirectory.Core.Dtos;
using UnitDirectory.Core.Entities;

namespace UnitDirectory.Application.Profiles
{
    internal class UnitDirectoryMappingProfile : Profile
    {
        public UnitDirectoryMappingProfile()
        {
            CreateMap<Unit, UnitDto>();
        }
    }
}
