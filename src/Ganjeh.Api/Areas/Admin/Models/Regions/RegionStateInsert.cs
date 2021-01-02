using System;
using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Areas.Admin.Models.Regions
{
    public class RegionStateInsert
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid CountryId { get; set; }
    }
}