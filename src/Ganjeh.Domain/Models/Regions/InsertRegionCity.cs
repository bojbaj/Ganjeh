using System;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Domain.Filters.Validations;

namespace Ganjeh.Domain.Models.Regions
{
    public class InsertRegionCity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [NonEmptyGuid]
        public Guid StateId { get; set; }
    }
}