using System;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Api.Filters.Validations;

namespace Ganjeh.Api.Areas.Admin.Models.Regions
{
    public class RegionStateUpdate
    {
        [Required]
        [NonEmptyGuid]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [NonEmptyGuid]
        public Guid CountryId { get; set; }
    }
}