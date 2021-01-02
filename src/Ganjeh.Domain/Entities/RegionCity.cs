using System;
using Ganjeh.Domain.Base;

namespace Ganjeh.Domain.Entities
{
    public class RegionCity : BaseEntity
    {
        public string Title { get; set; }
        public Guid RegionStateId { get; set; }
        public RegionState RegionState { get; set; }        
    }
}