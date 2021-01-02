using System;
using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Areas.Admin.Models.Regions
{
    public class RegionStateUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid CountryId { get; set; }
    }
}