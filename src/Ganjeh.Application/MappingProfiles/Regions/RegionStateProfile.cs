using Ganjeh.Application.MappingProfiles.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models.DTOs.Region;
using Ganjeh.Domain.Models.Regions;

namespace Ganjeh.Application.MappingProfiles.Regions
{
    public class RegionStateProfile : BaseProfile
    {
        public RegionStateProfile()
        {
            CreateMap<RegionState, StateDTO>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.RegionCountry))
                .ReverseMap();

            CreateMap<InsertRegionState, RegionState>();
        }
    }
}