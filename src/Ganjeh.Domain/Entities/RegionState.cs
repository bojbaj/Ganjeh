using System;
using System.Collections.Generic;
using Ganjeh.Domain.Base;

namespace Ganjeh.Domain.Entities
{
    public class RegionState : BaseEntity
    {
        public string Title { get; set; }
        public Guid RegionCountryId { get; set; }
        public RegionCountry RegionCountry { get; set; }
        public ICollection<RegionCity> RegionCities { get; set; }
    }
}