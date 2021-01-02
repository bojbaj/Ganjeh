using System;
using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Areas.Admin.Models.Regions
{
    public class RegionStateDelete
    {
        [Required]
        public Guid Id { get; set; }
    }
}