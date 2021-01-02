using System;
using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Areas.Admin.Models.Regions
{
    public class RegionCityInsert
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid StateId { get; set; }
    }
}