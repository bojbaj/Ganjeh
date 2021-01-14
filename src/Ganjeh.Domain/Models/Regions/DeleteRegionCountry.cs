using System;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Domain.Filters.Validations;

namespace Ganjeh.Domain.Models.Regions
{
    public class DeleteRegionCountry
    {
        [Required]
        [NonEmptyGuid]
        public Guid Id { get; set; }
    }
}