using System;
using System.ComponentModel.DataAnnotations.Schema;
using Ganjeh.Domain.Base;

namespace Ganjeh.Domain.Entities
{
    public class Address : BaseEntity
    {
        public Guid RegionCityId { get; set; }
        public RegionCity RegionCity { get; set; }
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        [Column(TypeName = "decimal(10,6)")]
        public decimal Lat { get; set; }
        [Column(TypeName = "decimal(10,6)")]
        public decimal Lng { get; set; }
    }
}