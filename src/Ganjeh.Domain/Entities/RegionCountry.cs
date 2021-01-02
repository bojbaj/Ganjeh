using System.Collections.Generic;
using Ganjeh.Domain.Base;

namespace Ganjeh.Domain.Entities
{
    public class RegionCountry : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<RegionState> RegionState { get; set; }
    }
}