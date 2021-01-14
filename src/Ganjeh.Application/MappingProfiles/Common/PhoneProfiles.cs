using Ganjeh.Application.MappingProfiles.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models.DTOs.Common;

namespace Ganjeh.Application.MappingProfiles.Common
{
    public class PhoneProfiles : BaseProfile
    {
        public PhoneProfiles()
        {
            CreateMap<Phone, PhoneDTO>()
                .ReverseMap();
        }
    }
}