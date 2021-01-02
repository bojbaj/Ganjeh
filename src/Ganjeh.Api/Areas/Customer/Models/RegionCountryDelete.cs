using System;
using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Areas.Customer.Models
{
    public class RegionCountryDelete
    {
        [Required]
        public Guid Id { get; set; }
    }
}