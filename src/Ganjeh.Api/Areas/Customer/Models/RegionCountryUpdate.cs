using System;
using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Areas.Customer.Models
{
    public class RegionCountryUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}