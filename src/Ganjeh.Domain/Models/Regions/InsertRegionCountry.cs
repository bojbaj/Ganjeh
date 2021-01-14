using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Domain.Models.Regions
{
    public class InsertRegionCountry
    {
        [Required]
        public string Title { get; set; }
    }
}