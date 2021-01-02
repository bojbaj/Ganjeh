using System;
using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Areas.Admin.Models.Regions
{
    public class RegionCityDelete
    {
        [Required]
        public Guid Id { get; set; }
    }
}