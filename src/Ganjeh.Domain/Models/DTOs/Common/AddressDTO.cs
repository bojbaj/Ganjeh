using Ganjeh.Domain.Enums;
using Ganjeh.Domain.Models.DTOs.Region;

namespace Ganjeh.Domain.Models.DTOs.Common
{
    public class AddressDTO : BaseDTORecord
    {
        public CityDTO RegionCity { get; set; }
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
    }
}