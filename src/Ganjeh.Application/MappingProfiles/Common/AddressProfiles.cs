using Ganjeh.Application.MappingProfiles.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models.DTOs.Common;

namespace Ganjeh.Application.MappingProfiles.Common
{
    public class AddressProfiles : BaseProfile
    {
        public AddressProfiles()
        {
            CreateMap<Address, AddressDTO>()
                .ReverseMap();
        }
    }
}