using System;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Api.Filters.Validations;

namespace Ganjeh.Api.Areas.Admin.Models.Regions
{
    public class RegionStateInsert
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [NonEmptyGuid]
        public Guid CountryId { get; set; }
    }
}