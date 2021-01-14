using System;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Domain.Filters.Validations;

namespace Ganjeh.Domain.Models.Regions
{
    public class UpdateRegionCountry
    {
        [Required]
        [NonEmptyGuid]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}