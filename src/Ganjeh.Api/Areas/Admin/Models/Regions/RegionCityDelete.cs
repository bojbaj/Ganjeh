using System;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Api.Filters.Validations;

namespace Ganjeh.Api.Areas.Admin.Models.Regions
{
    public class RegionCityDelete
    {
        [Required]
        [NonEmptyGuid]
        public Guid Id { get; set; }
    }
}