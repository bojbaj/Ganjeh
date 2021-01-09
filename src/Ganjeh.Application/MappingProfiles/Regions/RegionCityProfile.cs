using Ganjeh.Application.MappingProfiles.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models.DTOs.Region;

namespace Ganjeh.Application.MappingProfiles.Regions
{
    public class RegionCityProfile : BaseProfile
    {
        public RegionCityProfile()
        {
            CreateMap<RegionCity, CityDTO>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.RegionState))                
                .ReverseMap();
        }
    }
}