using Ganjeh.Application.MappingProfiles.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models.DTOs.Region;

namespace Ganjeh.Application.MappingProfiles.Regions
{
    public class RegionStateProfile : BaseProfile
    {
        public RegionStateProfile()
        {
            CreateMap<RegionState, StateDTO>()
                .ReverseMap();
        }
    }
}