using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Areas.Customer.Models
{
    public class RegionCountryInsert
    {
        [Required]
        public string Title { get; set; }
    }
}