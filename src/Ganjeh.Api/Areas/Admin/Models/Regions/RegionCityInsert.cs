using System;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Api.Filters.Validations;

namespace Ganjeh.Api.Areas.Admin.Models.Regions
{
    public class RegionCityInsert
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [NonEmptyGuid]
        public Guid StateId { get; set; }
    }
}