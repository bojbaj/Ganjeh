using Ganjeh.Application.MappingProfiles.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models.DTOs.Common;

namespace Ganjeh.Application.MappingProfiles.Common
{
    public class FileProfiles : BaseProfile
    {
        public FileProfiles()
        {
            CreateMap<File, FileDTO>()
                .ReverseMap();
        }
    }
}