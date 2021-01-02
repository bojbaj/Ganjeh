using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Areas.Admin.Models.Regions
{
    public class RegionCountryInsert
    {
        [Required]
        public string Title { get; set; }
    }
}