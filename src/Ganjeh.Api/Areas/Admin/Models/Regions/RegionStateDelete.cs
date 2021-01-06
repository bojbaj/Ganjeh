using System;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Api.Filters.Validations;

namespace Ganjeh.Api.Areas.Admin.Models.Regions
{
    public class RegionStateDelete
    {
        [Required]
        [NonEmptyGuid]
        public Guid Id { get; set; }
    }
}