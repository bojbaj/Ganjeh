using Ganjeh.Application.MappingProfiles.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models.DTOs.Region;
using Ganjeh.Domain.Models.Regions;

namespace Ganjeh.Application.MappingProfiles.Regions
{
    public class RegionCityProfile : BaseProfile
    {
        public RegionCityProfile()
        {
            CreateMap<RegionCity, CityDTO>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.RegionState))
                .ReverseMap();

            CreateMap<InsertRegionCity, RegionCity>()
                .ForMember(dest => dest.RegionStateId, opt => opt.MapFrom(src => src.StateId))
                .ReverseMap();
        }
    }
}