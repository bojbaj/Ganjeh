using System;
using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Areas.Admin.Models
{
    public class RegionCountryDelete
    {
        [Required]
        public Guid Id { get; set; }
    }
}